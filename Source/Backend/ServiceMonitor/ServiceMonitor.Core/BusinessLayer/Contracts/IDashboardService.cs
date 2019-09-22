using System.Threading.Tasks;
using ServiceMonitor.Core.BusinessLayer.Responses;
using ServiceMonitor.Core.Domain.DataContracts;
using ServiceMonitor.Core.Domain;

namespace ServiceMonitor.Core.BusinessLayer.Contracts
{
    public interface IDashboardService : IService
    {
        Task<IListResponse<ServiceWatcherItemDto>> GetActiveServiceWatcherItemsAsync();

        Task<IListResponse<ServiceStatusDetailDto>> GetServiceStatusesAsync(string userName);

        Task<ISingleResponse<ServiceEnvironmentStatus>> GetServiceStatusAsync(ServiceEnvironmentStatus entity);
    }
}
