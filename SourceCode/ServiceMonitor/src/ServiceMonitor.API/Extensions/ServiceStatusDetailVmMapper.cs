using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceStatusDetailVmMapper
    {
        public static ServiceStatusDetailDto ToEntity(this ServiceStatusDetailVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatusDetailVm, ServiceStatusDetailDto>(viewModel);

        public static ServiceStatusDetailVm ToViewModel(this ServiceStatusDetailDto entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatusDetailDto, ServiceStatusDetailVm>(entity);
    }
}
