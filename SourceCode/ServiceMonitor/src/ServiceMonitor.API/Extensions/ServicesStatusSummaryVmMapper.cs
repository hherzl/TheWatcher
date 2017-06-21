using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServicesStatusSummaryVmMapper
    {
        public static ServiceEnvironmentStatus ToEntity(this ServiceStatusVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatusVm, ServiceEnvironmentStatus>(viewModel);

        public static ServiceStatusVm ToViewModel(this ServiceEnvironmentStatus entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceEnvironmentStatus, ServiceStatusVm>(entity);
    }
}
