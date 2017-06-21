using System;
using System.Threading.Tasks;
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
        private IAdministrationRepository m_repository;

        public AdministrationBusinessObject(ServiceMonitorDbContext dbContext)
            : base(dbContext)
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
                    }
                    else
                    {
                        serviceEnvStatus.Success = entity.Success;
                        serviceEnvStatus.WatchCount += 1;
                        serviceEnvStatus.LastWatch = DateTime.Now;
                    }

                    entity.ServiceEnvironmentStatusID = serviceEnvStatus.ServiceEnvironmentStatusID;
                    
                    await Repository.CreateServiceEnvironmentStatusLogAsync(entity);

                    transaction.Commit();

                    response.Model = entity;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    response.DidError = true;
                    response.ErrorMessage = ex.Message;
                }
            }

            return response;
        }
    }
}
