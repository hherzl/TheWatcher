using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.Domain.DataContracts;

namespace ServiceMonitor.Core.Domain.Extensions
{
    public static class ServiceMonitorDbContextDashboardExtensions
    {
        public static IQueryable<ServiceWatcherItemInfo> GetActiveServiceWatcherItems(this ServiceMonitorDbContext dbContext)
        {
            return
                from serviceEnvironment in dbContext.ServiceEnvironments
                join service in dbContext.Services
                    on serviceEnvironment.ServiceID equals service.ID
                join serviceWatcher in dbContext.ServiceWatchers
                    on serviceEnvironment.ServiceID equals serviceWatcher.ServiceID
                join watcher in dbContext.Watchers
                    on serviceWatcher.WatcherID equals watcher.ID
                join environment in dbContext.Environments
                    on serviceEnvironment.EnvironmentID equals environment.ID
                select new ServiceWatcherItemInfo
                {
                    ServiceEnvironmentID = serviceEnvironment.ID,
                    ServiceID = service.ID,
                    Environment = environment.Name,
                    ServiceName = service.Name,
                    Interval = serviceEnvironment.Interval,
                    Url = serviceEnvironment.Url,
                    Address = serviceEnvironment.Address,
                    ConnectionString = serviceEnvironment.ConnectionString,
                    TypeName = watcher.AssemblyQualifiedName
                };
        }

        public static IQueryable<ServiceStatusDetailInfo> GetServiceStatuses(this ServiceMonitorDbContext dbContext, Guid userID)
        {
            var servicesToWatch = dbContext
                .ServiceUsers
                .Where(item => item.UserID == userID)
                .Select(item => item.ServiceID)
                .ToList();

            var query = from svcEnvStatus in dbContext.ServiceEnvironmentStatuses
                        join svcEnv in dbContext.ServiceEnvironments
                            on svcEnvStatus.ServiceEnvironmentID equals svcEnv.ID
                        join svc in dbContext.Services
                            on svcEnv.ServiceID equals svc.ID
                        join env in dbContext.Environments
                            on svcEnv.EnvironmentID equals env.ID
                        where
                            svcEnv.Active == true
                        select new ServiceStatusDetailInfo
                        {
                            ServiceEnvironmentStatusID = svcEnvStatus.ID,
                            ServiceEnvironmentID = svcEnvStatus.ServiceEnvironmentID,
                            ServiceID = svc.ID,
                            ServiceName = svc.Name,
                            EnvironmentName = env.Name,
                            Successful = svcEnvStatus.Successful,
                            WatchCount = svcEnvStatus.WatchCount,
                            LastWatch = svcEnvStatus.LastWatch
                        };

            query = query
                .OrderBy(item => item.ServiceName)
                .ThenBy(item => item.EnvironmentName);

            return query
                .Where(item => servicesToWatch.Contains(item.ServiceID));
        }

        public static async Task<ServiceEnvironmentStatus> GetServiceEnvironmentStatusByServiceEnvironmentAsync(this ServiceMonitorDbContext dbContext, ServiceEnvironment entity)
            => await dbContext.ServiceEnvironmentStatuses.FirstOrDefaultAsync(item => item.ServiceEnvironmentID == entity.ID);
    }
}
