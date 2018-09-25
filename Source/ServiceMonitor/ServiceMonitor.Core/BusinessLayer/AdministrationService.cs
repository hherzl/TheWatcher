using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Core.BusinessLayer.Responses;
using ServiceMonitor.Core.DataLayer;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.DataLayer.Repositories;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.BusinessLayer
{
    public class AdministrationService : Service, IAdministrationService
    {
        private IAdministrationRepository m_repository;

        public AdministrationService(ILogger<AdministrationService> logger, ServiceMonitorDbContext dbContext)
            : base(logger, dbContext)
        {
        }

        protected IAdministrationRepository Repository
            => m_repository ?? (m_repository = new AdministrationRepository(DbContext));

        public async Task<ISingleResponse<ServiceEnvironmentStatusLog>> CreateServiceEnvironmentStatusLogAsync(ServiceEnvironmentStatusLog entity, int? serviceEnvironmentID)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(CreateServiceEnvironmentStatusLogAsync));

            var response = new SingleResponse<ServiceEnvironmentStatusLog>();

            using (var transaction = await DbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var serviceEnvStatus = await Repository.GetByServiceEnvironmentAsync(new ServiceEnvironment { ServiceEnvironmentID = serviceEnvironmentID });

                    if (serviceEnvStatus == null)
                    {
                        serviceEnvStatus = new ServiceEnvironmentStatus
                        {
                            ServiceEnvironmentID = serviceEnvironmentID,
                            Success = entity.Success,
                            WatchCount = 1,
                            LastWatch = DateTime.Now
                        };

                        Repository.Add(serviceEnvStatus);

                        await Repository.SaveChangesAsync();

                        Logger?.LogInformation("The status for service environment was saved successfully");
                    }
                    else
                    {
                        serviceEnvStatus.Success = entity.Success;
                        serviceEnvStatus.WatchCount += 1;
                        serviceEnvStatus.LastWatch = DateTime.Now;

                        Logger?.LogInformation("The status for service environment was updated successfully");
                    }

                    entity.ServiceEnvironmentStatusID = serviceEnvStatus.ServiceEnvironmentStatusID;
                    entity.Date = DateTime.Now;

                    Repository.Add(entity);

                    await Repository.SaveChangesAsync();

                    Logger?.LogInformation("The status details for service environment was created successfully");

                    transaction.Commit();

                    response.Model = entity;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    response.SetError(Logger, ex);
                }
            }

            return response;
        }
    }
}
