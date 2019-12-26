using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Core.Business.Contracts;
using ServiceMonitor.Core.Business.Responses;
using ServiceMonitor.Core.Business.Responses.Contracts;
using ServiceMonitor.Core.Domain;
using ServiceMonitor.Core.Domain.Extensions;

namespace ServiceMonitor.Core.Business
{
    public class AdministrationService : BaseService, IAdministrationService
    {
        public AdministrationService(ILogger<AdministrationService> logger, ServiceMonitorDbContext dbContext)
            : base(logger, dbContext)
        {
        }

        public async Task<ISingleResponse<ServiceEnvironmentStatusLog>> CreateServiceEnvironmentStatusLogAsync(ServiceEnvironmentStatusLog entity, short? serviceEnvironmentID)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(CreateServiceEnvironmentStatusLogAsync));

            var response = new SingleResponse<ServiceEnvironmentStatusLog>();

            using (var txn = await DbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var serviceEnvStatus = await DbContext
                        .GetServiceEnvironmentStatusByServiceEnvironmentAsync(new ServiceEnvironment(serviceEnvironmentID));

                    if (serviceEnvStatus == null)
                    {
                        serviceEnvStatus = new ServiceEnvironmentStatus
                        {
                            ServiceEnvironmentID = serviceEnvironmentID,
                            Successful = entity.Successful,
                            WatchCount = 1,
                            LastWatch = DateTime.Now
                        };

                        DbContext.ServiceEnvironmentStatuses.Add(serviceEnvStatus);

                        await DbContext.SaveChangesAsync();

                        Logger?.LogInformation("The status for service environment was saved successfully");
                    }
                    else
                    {
                        serviceEnvStatus.Successful = entity.Successful;
                        serviceEnvStatus.WatchCount += 1;
                        serviceEnvStatus.LastWatch = DateTime.Now;

                        Logger?.LogInformation("The status for service environment was updated successfully");
                    }

                    entity.ServiceEnvironmentStatusID = serviceEnvStatus.ID;
                    entity.Date = DateTime.Now;

                    DbContext.ServiceEnvironmentStatusLogs.Add(entity);

                    await DbContext.SaveChangesAsync();

                    Logger?.LogInformation("The status details for service environment was created successfully");

                    txn.Commit();

                    response.Model = entity;
                }
                catch (Exception ex)
                {
                    txn.Rollback();

                    response.SetError(Logger, nameof(CreateServiceEnvironmentStatusLogAsync), ex);
                }
            }

            return response;
        }
    }
}
