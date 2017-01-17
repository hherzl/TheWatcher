using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceWatcherItemViewModelMapper
    {
        public static ServiceWatcherItem ToEntity(this ServiceWatcherItemViewModel viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcherItemViewModel, ServiceWatcherItem>(viewModel);

        public static ServiceWatcherItemViewModel ToViewModel(this ServiceWatcherItem entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcherItem, ServiceWatcherItemViewModel>(entity);
    }
}
