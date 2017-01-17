using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceViewModelMapper
    {
        public static Service ToEntity(this ServiceViewModel viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceViewModel, Service>(viewModel);

        public static ServiceViewModel ToViewModel(this Service entity)
            => ViewModelMapper.ConfigMapper.Map<Service, ServiceViewModel>(entity);
    }
}
