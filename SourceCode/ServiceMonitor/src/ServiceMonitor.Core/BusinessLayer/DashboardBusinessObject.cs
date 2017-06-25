using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Core.BusinessLayer.Responses;
using ServiceMonitor.Core.DataLayer;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.DataLayer.Repositories;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.BusinessLayer
{
    public partial class DashboardBusinessObject : BusinessObject, IDashboardBusinessObject
    {
        private IDashboardRepository m_repository;

        public DashboardBusinessObject(ServiceMonitorDbContext dbContext)
            : base(dbContext)
        {
        }

        protected IDashboardRepository Repository
        {
            get
            {
                return m_repository ?? (m_repository = new DashboardRepository(DbContext));
            }
        }

        public async Task<IListViewModelResponse<ServiceWatcherItemDto>> GetActiveServiceWatcherItemsAsync()
        {
            var response = new ListViewModelResponse<ServiceWatcherItemDto>();

            try
            {
                response.Model = await Repository.GetActiveServiceWatcherItems().ToListAsync();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<IListViewModelResponse<ServiceStatusDetailDto>> GetServiceStatusesAsync(String userName)
        {
            var response = new ListViewModelResponse<ServiceStatusDetailDto>();

            try
            {
                var user = Repository.GetUser(userName);

                if (user == null)
                {
                    return new ListViewModelResponse<ServiceStatusDetailDto>();
                }
                else
                {
                    response.Model = await Repository
                        .GetServiceStatuses(userName)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ISingleViewModelResponse<ServiceEnvironmentStatus>> GetServiceStatusAsync(ServiceEnvironmentStatus entity)
        {
            var response = new SingleViewModelResponse<ServiceEnvironmentStatus>();

            try
            {
                response.Model = await Repository.GetServiceEnvironmentStatusAsync(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}
