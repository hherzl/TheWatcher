using System;
using System.Linq;
using System.Threading.Tasks;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Contracts
{
    public interface IDashboardRepository : IRepository
    {
        IQueryable<ServiceWatcherItemDto> GetActiveServiceWatcherItems();

        User GetUser(String userName);

        IQueryable<ServiceUser> GetByUser(Int32? userID);

        IQueryable<ServiceStatusDetailDto> GetServiceStatuses(String userName);

        Task<ServiceEnvironmentStatus> GetServiceEnvironmentStatusAsync(ServiceEnvironmentStatus entity);
    }
}
