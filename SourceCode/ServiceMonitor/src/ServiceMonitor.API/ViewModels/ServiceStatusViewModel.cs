using System;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.ViewModels
{
    public class ServiceStatusViewModel
    {
        public ServiceStatusViewModel()
        {
        }

        public Int32? ServiceStatusID { get; set; }

        public Int32? ServiceID { get; set; }

        public Boolean? Success { get; set; }

        public Int32? WatchCount { get; set; }

        public DateTime? LastWatch { get; set; }
    }

    public static class ServicesStatusSummaryViewModelMapper
    {
        public static ServiceStatus ToEntity(this ServiceStatusViewModel viewModel)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceStatusViewModel, ServiceStatus>(viewModel);
        }

        public static ServiceStatusViewModel ToViewModel(this ServiceStatus entity)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceStatus, ServiceStatusViewModel>(entity);
        }
    }
}
