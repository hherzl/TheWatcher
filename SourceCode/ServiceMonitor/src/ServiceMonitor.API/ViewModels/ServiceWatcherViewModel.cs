using System;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.ViewModels
{
    public class ServiceWatcherViewModel
    {
        public ServiceWatcherViewModel()
        {
        }

        public Int32? ServiceWatcherID { get; set; }

        public Int32? ServiceID { get; set; }

        public String TypeName { get; set; }
    }

    public static class ServiceWatcherViewModelMapper
    {
        public static ServiceWatcher ToEntity(this ServiceWatcherViewModel viewModel)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceWatcherViewModel, ServiceWatcher>(viewModel);
        }

        public static ServiceWatcherViewModel ToViewModel(this ServiceWatcher entity)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceWatcher, ServiceWatcherViewModel>(entity);
        }
    }
}
