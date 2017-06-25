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
    public partial class AdministrationBusinessObject : BusinessObject, IAdministrationBusinessObject
    {
        private ILogger logger;
        private IAdministrationRepository m_repository;

        public AdministrationBusinessObject(ILogger logger, ServiceMonitorDbContext dbContext)
            : base(logger, dbContext)
        {
        }

        protected IAdministrationRepository Repository
        {
            get
            {
                return m_repository ?? (m_repository = new AdministrationRepository(DbContext));
            }
        }

        public async Task<ISingleViewModelResponse<ServiceEnvironmentStatusLog>> CreateServiceEnvironmentStatusLogAsync(ServiceEnvironmentStatusLog entity, Int32? serviceEnvironmentID)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(CreateServiceEnvironmentStatusLogAsync));

            var response = new SingleViewModelResponse<ServiceEnvironmentStatusLog>();

            using (var transaction = await DbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var serviceEnvStatus = await Repository.GetByServiceEnvironmentAsync(new ServiceEnvironment { ServiceEnvironmentID = serviceEnvironmentID });

                    if (serviceEnvStatus == null)
                    {
                        serviceEnvStatus = new ServiceEnvironmentStatus();

                        serviceEnvStatus.ServiceEnvironmentID = serviceEnvironmentID;
                        serviceEnvStatus.Success = entity.Success;
                        serviceEnvStatus.WatchCount = 1;
                        serviceEnvStatus.LastWatch = DateTime.Now;

                        await Repository.CreateServiceEnvironmentStatusAsync(serviceEnvStatus);

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

                    await Repository.CreateServiceEnvironmentStatusLogAsync(entity);

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
