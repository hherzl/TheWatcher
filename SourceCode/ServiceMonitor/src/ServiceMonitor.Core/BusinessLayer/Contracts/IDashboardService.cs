using System;
using System.Threading.Tasks;
using ServiceMonitor.Core.BusinessLayer.Responses;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.BusinessLayer.Contracts
{
    public interface IDashboardService : IService
    {
        Task<IListViewModelResponse<ServiceWatcherItemDto>> GetActiveServiceWatcherItemsAsync();

        Task<IListViewModelResponse<ServiceStatusDetailDto>> GetServiceStatusesAsync(String userName);

        Task<ISingleViewModelResponse<ServiceEnvironmentStatus>> GetServiceStatusAsync(ServiceEnvironmentStatus entity);
    }
}
