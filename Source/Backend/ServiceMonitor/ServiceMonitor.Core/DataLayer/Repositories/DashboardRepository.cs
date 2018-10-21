using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Repositories
{
    public class DashboardRepository : Repository, IDashboardRepository
    {
        public DashboardRepository(ServiceMonitorDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<ServiceWatcherItemDto> GetActiveServiceWatcherItems()
        {
            return from serviceEnvironment in DbContext.ServiceEnvironment
                   join service in DbContext.Service on serviceEnvironment.ServiceID equals service.ServiceID
                   join serviceWatcher in DbContext.ServiceWatcher on serviceEnvironment.ServiceID equals serviceWatcher.ServiceID
                   join environmentCategory in DbContext.EnvironmentCategory on serviceEnvironment.EnvironmentCategoryID equals environmentCategory.EnvironmentCategoryID
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

        public User GetUser(string userName)
            => DbContext.User.FirstOrDefault(item => item.UserName == userName);

        public IQueryable<ServiceUser> GetServiceUserByUserID(int? userID)
            => DbContext.ServiceUser.Where(item => item.UserID == userID);

        public IQueryable<ServiceStatusDetailDto> GetServiceStatuses(string userName)
        {
            var user = GetUser(userName);

            if (user == null)
                return new List<ServiceStatusDetailDto>().AsQueryable();

            var servicesToWatch = DbContext
                .ServiceUser
                .Where(item => item.UserID == user.UserID)
                .Select(item => item.ServiceID)
                .ToList();

            var query = from serviceEnvironmentStatus in DbContext.ServiceEnvironmentStatus
                        join serviceEnvironment in DbContext.ServiceEnvironment on serviceEnvironmentStatus.ServiceEnvironmentID equals serviceEnvironment.ServiceEnvironmentID
                        join service in DbContext.Service on serviceEnvironment.ServiceID equals service.ServiceID
                        join environmentCategory in DbContext.EnvironmentCategory on serviceEnvironment.EnvironmentCategoryID equals environmentCategory.EnvironmentCategoryID
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

        public async Task<ServiceEnvironmentStatus> GetServiceEnvironmentStatusAsync(ServiceEnvironmentStatus entity)
            => await DbContext.ServiceEnvironmentStatus.FirstOrDefaultAsync(item => item.ServiceEnvironmentStatusID == entity.ServiceEnvironmentStatusID);
    }
}
