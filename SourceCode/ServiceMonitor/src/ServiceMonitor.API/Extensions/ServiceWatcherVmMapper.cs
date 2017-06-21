using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceWatcherVmMapper
    {
        public static ServiceWatcher ToEntity(this ServiceWatcherVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcherVm, ServiceWatcher>(viewModel);

        public static ServiceWatcherVm ToViewModel(this ServiceWatcher entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcher, ServiceWatcherVm>(entity);
    }
}
