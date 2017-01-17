using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceStatusDetailViewModelMapper
    {
        public static ServiceStatusDetail ToEntity(this ServiceStatusDetailViewModel viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatusDetailViewModel, ServiceStatusDetail>(viewModel);

        public static ServiceStatusDetailViewModel ToViewModel(this ServiceStatusDetail entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatusDetail, ServiceStatusDetailViewModel>(entity);
    }
}
