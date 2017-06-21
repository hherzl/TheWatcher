using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceStatusLogVmMapper
    {
        public static ServiceEnvironmentStatusLog ToEntity(this ServiceEnvironmentStatusLogVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceEnvironmentStatusLogVm, ServiceEnvironmentStatusLog>(viewModel);

        public static ServiceEnvironmentStatusLogVm ToViewModel(this ServiceEnvironmentStatusLog entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceEnvironmentStatusLog, ServiceEnvironmentStatusLogVm>(entity);
    }
}
