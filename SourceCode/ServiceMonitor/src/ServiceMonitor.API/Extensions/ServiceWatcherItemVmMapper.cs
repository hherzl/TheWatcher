using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceWatcherItemVmMapper
    {
        public static ServiceWatcherItemDto ToEntity(this ServiceWatcherItemVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcherItemVm, ServiceWatcherItemDto>(viewModel);

        public static ServiceWatcherItemVm ToViewModel(this ServiceWatcherItemDto entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcherItemDto, ServiceWatcherItemVm>(entity);
    }
}
