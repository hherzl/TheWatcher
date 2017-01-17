using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceStatusLogViewModelMapper
    {
        public static ServiceStatusLog ToEntity(this ServiceStatusLogViewModel viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatusLogViewModel, ServiceStatusLog>(viewModel);

        public static ServiceStatusLogViewModel ToViewModel(this ServiceStatusLog entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatusLog, ServiceStatusLogViewModel>(entity);
    }
}
