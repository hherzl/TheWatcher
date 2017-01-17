using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServicesStatusSummaryViewModelMapper
    {
        public static ServiceStatus ToEntity(this ServiceStatusViewModel viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatusViewModel, ServiceStatus>(viewModel);

        public static ServiceStatusViewModel ToViewModel(this ServiceStatus entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatus, ServiceStatusViewModel>(entity);
    }
}
