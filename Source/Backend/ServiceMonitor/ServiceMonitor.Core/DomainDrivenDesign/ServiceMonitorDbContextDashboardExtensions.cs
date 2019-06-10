using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.DomainDrivenDesign.DataContracts;

namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public static class ServiceMonitorDbContextDashboardExtensions
    {
        public static IQueryable<ServiceWatcherItemDto> GetActiveServiceWatcherItems(this ServiceMonitorDbContext dbContext)
        {
            return from serviceEnvironment in dbContext.ServiceEnvironments
                   join service in dbContext.Services
                    on serviceEnvironment.ServiceID equals service.ID
                   join serviceWatcher in dbContext.ServiceWatchers
                    on serviceEnvironment.ServiceID equals serviceWatcher.ServiceID
                   join environmentCategory in dbContext.EnvironmentCategories
                    on serviceEnvironment.EnvironmentCategoryID equals environmentCategory.ID
                   select new ServiceWatcherItemDto
                   {
                       ServiceEnvironmentID = serviceEnvironment.ID,
                       ServiceID = service.ID,
                       Environment = environmentCategory.Name,
                       ServiceName = service.Name,
                       Interval = serviceEnvironment.Interval,
                       Url = serviceEnvironment.Url,
                       Address = serviceEnvironment.Address,
                       ConnectionString = serviceEnvironment.ConnectionString,
                       TypeName = serviceWatcher.TypeName
                   };
        }

        public static async Task<User> GetUserAsync(this ServiceMonitorDbContext dbContext, string userName)
            => await dbContext.Users.FirstOrDefaultAsync(item => item.UserName == userName);

        public static IQueryable<ServiceUser> GetServiceUserByUserID(this ServiceMonitorDbContext dbContext, int? userID)
            => dbContext.ServiceUsers.Where(item => item.UserID == userID);

        public static IQueryable<ServiceStatusDetailDto> GetServiceStatuses(this ServiceMonitorDbContext dbContext, User user)
        {
            if (user == null)
                return new List<ServiceStatusDetailDto>().AsQueryable();

            var servicesToWatch = dbContext
                .ServiceUsers
                .Where(item => item.UserID == user.ID)
                .Select(item => item.ServiceID)
                .ToList();

            var query = from serviceEnvironmentStatus in dbContext.ServiceEnvironmentStatuses
                        join serviceEnvironment in dbContext.ServiceEnvironments
                            on serviceEnvironmentStatus.ServiceEnvironmentID equals serviceEnvironment.ID
                        join service in dbContext.Services on serviceEnvironment.ServiceID equals service.ID
                        join environmentCategory in dbContext.EnvironmentCategories
                            on serviceEnvironment.EnvironmentCategoryID equals environmentCategory.ID
                        where serviceEnvironment.Active == true
                        select new ServiceStatusDetailDto
                        {
                            ServiceEnvironmentStatusID = serviceEnvironmentStatus.ID,
                            ServiceEnvironmentID = serviceEnvironmentStatus.ServiceEnvironmentID,
                            ServiceID = service.ID,
                            ServiceName = service.Name,
                            EnvironmentName = environmentCategory.Name,
                            Success = serviceEnvironmentStatus.Success,
                            WatchCount = serviceEnvironmentStatus.WatchCount,
                            LastWatch = serviceEnvironmentStatus.LastWatch
                        };

            query = query.OrderBy(item => item.ServiceName).ThenBy(item => item.EnvironmentName);

            return query.Where(item => servicesToWatch.Contains(item.ServiceID));
        }

        public static async Task<ServiceEnvironmentStatus> GetServiceEnvironmentStatusAsync(this ServiceMonitorDbContext dbContext, ServiceEnvironmentStatus entity)
            => await dbContext.ServiceEnvironmentStatuses.FirstOrDefaultAsync(item => item.ID == entity.ID);
    }
}
