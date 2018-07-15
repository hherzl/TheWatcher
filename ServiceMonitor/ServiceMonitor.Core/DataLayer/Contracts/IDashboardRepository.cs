using System.Linq;
using System.Threading.Tasks;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Contracts
{
    public interface IDashboardRepository : IRepository
    {
        IQueryable<ServiceWatcherItemDto> GetActiveServiceWatcherItems();

        User GetUser(string userName);

        IQueryable<ServiceUser> GetByUser(int? userID);

        IQueryable<ServiceStatusDetailDto> GetServiceStatuses(string userName);

        Task<ServiceEnvironmentStatus> GetServiceEnvironmentStatusAsync(ServiceEnvironmentStatus entity);
    }
}
