using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceWatcherViewModelMapper
    {
        public static ServiceWatcher ToEntity(this ServiceWatcherViewModel viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcherViewModel, ServiceWatcher>(viewModel);

        public static ServiceWatcherViewModel ToViewModel(this ServiceWatcher entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcher, ServiceWatcherViewModel>(entity);
    }
}
