using System;
using System.Linq;
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

        public async Task<IListResponse<ServiceStatusDetailInfo>> GetServiceStatusesAsync(Guid userID)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceStatusesAsync));

            var response = new ListResponse<ServiceStatusDetailInfo>();

            try
            {
                response.Model = await DbContext.GetServiceStatuses(userID).ToListAsync();

                if (response.Model?.Count() == 0)
                    Logger?.LogInformation("There is no data for user with ID '{0}'", userID);
                else
                    Logger?.LogInformation("The service status details for user with ID '{0}' were loaded successfully", userID);
            }
            catch (Exception ex)
            {
                response.SetError(Logger, nameof(GetServiceStatusesAsync), ex);
            }

            return response;
        }
    }
}
