using System;
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
            var query = from serviceEnvironment in DbContext.Set<ServiceEnvironment>()
                        join service in DbContext.Set<Service>() on serviceEnvironment.ServiceID equals service.ServiceID
                        join serviceWatcher in DbContext.Set<ServiceWatcher>() on serviceEnvironment.ServiceID equals serviceWatcher.ServiceID
                        join environmentCategory in DbContext.Set<EnvironmentCategory>() on serviceEnvironment.EnvironmentCategoryID equals environmentCategory.EnvironmentCategoryID
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

            return query.AsQueryable();
        }

        public User GetUser(String userName)
        {
            return DbContext
                .Set<User>()
                .FirstOrDefault(item => item.UserName == userName);
        }

        public IQueryable<ServiceUser> GetByUser(Int32? userID)
        {
            return DbContext
                .Set<ServiceUser>()
                .Where(item => item.UserID == userID);
        }

        public IQueryable<ServiceStatusDetailDto> GetServiceStatuses(String userName)
        {
            var user = GetUser(userName);

            if (user == null)
            {
                return new List<ServiceStatusDetailDto>().AsQueryable();
            }
            else
            {
                var servicesToWatch = DbContext
                    .Set<ServiceUser>()
                    .Where(item => item.UserID == user.UserID)
                    .Select(item => item.ServiceID)
                    .ToList();

                var query = from serviceEnvironmentStatus in DbContext.Set<ServiceEnvironmentStatus>()
                            join serviceEnvironment in DbContext.Set<ServiceEnvironment>() on serviceEnvironmentStatus.ServiceEnvironmentID equals serviceEnvironment.ServiceEnvironmentID
                            join service in DbContext.Set<Service>() on serviceEnvironment.ServiceID equals service.ServiceID
                            where serviceEnvironment.Active == true
                            select new ServiceStatusDetailDto
                            {
                                ServiceEnvironmentStatusID = serviceEnvironmentStatus.ServiceEnvironmentStatusID,
                                ServiceEnvironmentID = serviceEnvironmentStatus.ServiceEnvironmentID,
                                ServiceName = service.Name,
                                Success = serviceEnvironmentStatus.Success,
                                WatchCount = serviceEnvironmentStatus.WatchCount,
                                LastWatch = serviceEnvironmentStatus.LastWatch
                            };

                return query.Where(item => servicesToWatch.Contains(item.ServiceEnvironmentID));
            }
        }

        public async Task<ServiceEnvironmentStatus> GetServiceEnvironmentStatusAsync(ServiceEnvironmentStatus entity)
        {
            return await DbContext
                .Set<ServiceEnvironmentStatus>()
                .FirstOrDefaultAsync(item => item.ServiceEnvironmentStatusID == entity.ServiceEnvironmentStatusID);
        }
    }
}
