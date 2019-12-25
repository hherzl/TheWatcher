using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Core.Business.Contracts;
using ServiceMonitor.Core.Business.Responses;
using ServiceMonitor.Core.Business.Responses.Contracts;
using ServiceMonitor.Core.Domain;
using ServiceMonitor.Core.Domain.DataContracts;
using ServiceMonitor.Core.Domain.Extensions;

namespace ServiceMonitor.Core.Business
{
    public class DashboardService : BaseService, IDashboardService
    {
        public DashboardService(ILogger<DashboardService> logger, ServiceMonitorDbContext dbContext)
            : base(logger, dbContext)
        {
        }

        public async Task<IListResponse<ServiceWatcherItemInfo>> GetActiveServiceWatcherItemsAsync()
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetActiveServiceWatcherItemsAsync));

            var response = new ListResponse<ServiceWatcherItemInfo>();

            try
            {
                response.Model = await DbContext.GetActiveServiceWatcherItems().ToListAsync();

                Logger?.LogInformation("The service watch items were loaded successfully");
            }
            catch (Exception ex)
            {
                response.SetError(Logger, nameof(GetActiveServiceWatcherItemsAsync), ex);
            }

            return response;
        }

        public async Task<IListResponse<ServiceStatusDetailInfo>> GetServiceStatusesAsync(string userName)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceStatusesAsync));

            var response = new ListResponse<ServiceStatusDetailInfo>();

            try
            {
                var user = await DbContext.GetUserAsync(userName);

                if (user == null)
                {
                    Logger?.LogInformation("There isn't data for user '{0}'", userName);

                    return new ListResponse<ServiceStatusDetailInfo>();
                }
                else
                {
                    response.Model = await DbContext.GetServiceStatuses(user).ToListAsync();

                    Logger?.LogInformation("The service status details for '{0}' user were loaded successfully", userName);
                }
            }
            catch (Exception ex)
            {
                response.SetError(Logger, nameof(GetServiceStatusesAsync), ex);
            }

            return response;
        }

        public async Task<ISingleResponse<ServiceEnvironmentStatus>> GetServiceStatusAsync(ServiceEnvironmentStatus entity)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceStatusAsync));

            var response = new SingleResponse<ServiceEnvironmentStatus>();

            try
            {
                response.Model = await DbContext.GetServiceEnvironmentStatusAsync(entity);
            }
            catch (Exception ex)
            {
                response.SetError(Logger, nameof(GetServiceStatusAsync), ex);
            }

            return response;
        }
    }
}
