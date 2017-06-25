using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private ILogger logger;
        private IDashboardRepository m_repository;

        public DashboardBusinessObject(ILogger logger, ServiceMonitorDbContext dbContext)
            : base(logger, dbContext)
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
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetActiveServiceWatcherItemsAsync));

            var response = new ListViewModelResponse<ServiceWatcherItemDto>();

            try
            {
                response.Model = await Repository
                    .GetActiveServiceWatcherItems()
                    .ToListAsync();

                Logger?.LogInformation("The service watch items were loaded successfully");
            }
            catch (Exception ex)
            {
                response.SetError(Logger, ex);
            }

            return response;
        }

        public async Task<IListViewModelResponse<ServiceStatusDetailDto>> GetServiceStatusesAsync(String userName)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceStatusesAsync));

            var response = new ListViewModelResponse<ServiceStatusDetailDto>();

            try
            {
                var user = Repository.GetUser(userName);

                if (user == null)
                {
                    Logger?.LogInformation("There isn't data for user '{0}'", userName);

                    return new ListViewModelResponse<ServiceStatusDetailDto>();
                }
                else
                {
                    response.Model = await Repository
                        .GetServiceStatuses(userName)
                        .ToListAsync();

                    Logger?.LogInformation("The service status details for '{0}' user were loaded successfully", userName);
                }
            }
            catch (Exception ex)
            {
                response.SetError(Logger, ex);
            }

            return response;
        }

        public async Task<ISingleViewModelResponse<ServiceEnvironmentStatus>> GetServiceStatusAsync(ServiceEnvironmentStatus entity)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceStatusAsync));

            var response = new SingleViewModelResponse<ServiceEnvironmentStatus>();

            try
            {
                response.Model = await Repository
                    .GetServiceEnvironmentStatusAsync(entity);
            }
            catch (Exception ex)
            {
                response.SetError(Logger, ex);
            }

            return response;
        }
    }
}
