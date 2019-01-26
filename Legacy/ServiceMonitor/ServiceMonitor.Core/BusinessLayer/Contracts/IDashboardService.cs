using System.Threading.Tasks;
using ServiceMonitor.Core.BusinessLayer.Responses;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.BusinessLayer.Contracts
{
    public interface IDashboardService : IService
    {
        Task<IListResponse<ServiceWatcherItemDto>> GetActiveServiceWatcherItemsAsync();

        Task<IListResponse<ServiceStatusDetailDto>> GetServiceStatusesAsync(string userName);

        Task<ISingleResponse<ServiceEnvironmentStatus>> GetServiceStatusAsync(ServiceEnvironmentStatus entity);
    }
}
