using System;
using ServiceMonitor.Core.DataLayer.DataContracts;

namespace ServiceMonitor.ViewModels
{
    public class ServiceWatcherItemViewModel
    {
        public ServiceWatcherItemViewModel()
        {

        }

        public Int32? ServiceID { get; set; }

        public String ServiceName { get; set; }

        public Int32? Interval { get; set; }

        public String Url { get; set; }

        public String Address { get; set; }

        public String ProviderName { get; set; }

        public String ConnectionString { get; set; }

        public String TypeName { get; set; }
    }

    public static class ServiceWatcherItemViewModelMapper
    {
        public static ServiceWatcherItem ToEntity(this ServiceWatcherItemViewModel viewModel)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceWatcherItemViewModel, ServiceWatcherItem>(viewModel);
        }

        public static ServiceWatcherItemViewModel ToViewModel(this ServiceWatcherItem entity)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceWatcherItem, ServiceWatcherItemViewModel>(entity);
        }
    }
}
