using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.DomainDrivenDesign.DataContracts;
using ServiceMonitor.Core.DomainDrivenDesign;

namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public static class ServiceMonitorDbContextDashboardExtensions
    {
        public static IQueryable<ServiceWatcherItemDto> GetActiveServiceWatcherItems(this ServiceMonitorDbContext dbContext)
        {
            return from serviceEnvironment in dbContext.ServiceEnvironment
                   join service in dbContext.Service on serviceEnvironment.ServiceID equals service.ServiceID
                   join serviceWatcher in dbContext.ServiceWatcher on serviceEnvironment.ServiceID equals serviceWatcher.ServiceID
                   join environmentCategory in dbContext.EnvironmentCategory on serviceEnvironment.EnvironmentCategoryID equals environmentCategory.EnvironmentCategoryID
                   select new ServiceWatcherItemDto
                   {
                       ServiceEnvironmentID = serviceEnvironment.ServiceEnvironmentID,
                       ServiceID = service.ServiceID,
                       Environment = environmentCategory.EnvironmentCategoryName,
                       ServiceName = service.Name,
                       Interval = serviceEnvironment.Interval,
                       Url = serviceEnvironment.Url,
                       Address = serviceEnvironment.Address,
                       ConnectionString = serviceEnvironment.ConnectionString,
                       TypeName = serviceWatcher.TypeName
                   };
        }

        public static async Task<User> GetUserAsync(this ServiceMonitorDbContext dbContext, string userName)
            => await dbContext.User.FirstOrDefaultAsync(item => item.UserName == userName);

        public static IQueryable<ServiceUser> GetServiceUserByUserID(this ServiceMonitorDbContext dbContext, int? userID)
            => dbContext.ServiceUser.Where(item => item.UserID == userID);

        public static IQueryable<ServiceStatusDetailDto> GetServiceStatuses(this ServiceMonitorDbContext dbContext, User user)
        {
            if (user == null)
                return new List<ServiceStatusDetailDto>().AsQueryable();

            var servicesToWatch = dbContext
                .ServiceUser
                .Where(item => item.UserID == user.UserID)
                .Select(item => item.ServiceID)
                .ToList();

            var query = from serviceEnvironmentStatus in dbContext.ServiceEnvironmentStatus
                        join serviceEnvironment in dbContext.ServiceEnvironment on serviceEnvironmentStatus.ServiceEnvironmentID equals serviceEnvironment.ServiceEnvironmentID
                        join service in dbContext.Service on serviceEnvironment.ServiceID equals service.ServiceID
                        join environmentCategory in dbContext.EnvironmentCategory on serviceEnvironment.EnvironmentCategoryID equals environmentCategory.EnvironmentCategoryID
                        where serviceEnvironment.Active == true
                        select new ServiceStatusDetailDto
                        {
                            ServiceEnvironmentStatusID = serviceEnvironmentStatus.ServiceEnvironmentStatusID,
                            ServiceEnvironmentID = serviceEnvironmentStatus.ServiceEnvironmentID,
                            ServiceID = service.ServiceID,
                            ServiceName = service.Name,
                            EnvironmentName = environmentCategory.EnvironmentCategoryName,
                            Success = serviceEnvironmentStatus.Success,
                            WatchCount = serviceEnvironmentStatus.WatchCount,
                            LastWatch = serviceEnvironmentStatus.LastWatch
                        };

            query = query.OrderBy(item => item.ServiceName).ThenBy(item => item.EnvironmentName);

            return query.Where(item => servicesToWatch.Contains(item.ServiceID));
        }

        public static async Task<ServiceEnvironmentStatus> GetServiceEnvironmentStatusAsync(this ServiceMonitorDbContext dbContext, ServiceEnvironmentStatus entity)
            => await dbContext.ServiceEnvironmentStatus.FirstOrDefaultAsync(item => item.ServiceEnvironmentStatusID == entity.ServiceEnvironmentStatusID);
    }
}
