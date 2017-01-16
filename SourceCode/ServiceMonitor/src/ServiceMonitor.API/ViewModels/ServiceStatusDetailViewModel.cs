using System;
using ServiceMonitor.Core.DataLayer.DataContracts;

namespace ServiceMonitor.ViewModels
{
    public class ServiceStatusDetailViewModel
    {
        public ServiceStatusDetailViewModel()
        {
        }

        public Int32? ServiceStatusID { get; set; }

        public Int32? ServiceID { get; set; }

        public String ServiceName { get; set; }

        public Boolean? Success { get; set; }

        public Int32? WatchCount { get; set; }

        public DateTime? LastWatch { get; set; }
    }

    public static class ServiceStatusDetailViewModelMapper
    {
        public static ServiceStatusDetail ToEntity(this ServiceStatusDetailViewModel viewModel)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceStatusDetailViewModel, ServiceStatusDetail>(viewModel);
        }

        public static ServiceStatusDetailViewModel ToViewModel(this ServiceStatusDetail entity)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceStatusDetail, ServiceStatusDetailViewModel>(entity);
        }
    }
}
