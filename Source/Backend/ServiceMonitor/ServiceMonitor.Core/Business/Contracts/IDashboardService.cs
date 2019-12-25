using System.Threading.Tasks;
using ServiceMonitor.Core.Business.Responses.Contracts;
using ServiceMonitor.Core.Domain;
using ServiceMonitor.Core.Domain.DataContracts;

namespace ServiceMonitor.Core.Business.Contracts
{
    public interface IDashboardService : IService
    {
        Task<IListResponse<ServiceWatcherItemInfo>> GetActiveServiceWatcherItemsAsync();

        Task<IListResponse<ServiceStatusDetailInfo>> GetServiceStatusesAsync(string userName);

        Task<ISingleResponse<ServiceEnvironmentStatus>> GetServiceStatusAsync(ServiceEnvironmentStatus entity);
    }
}
