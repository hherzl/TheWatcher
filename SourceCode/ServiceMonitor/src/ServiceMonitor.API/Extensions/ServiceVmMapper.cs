using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceVmMapper
    {
        public static Service ToEntity(this ServiceVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceVm, Service>(viewModel);

        public static ServiceVm ToViewModel(this Service entity)
            => ViewModelMapper.ConfigMapper.Map<Service, ServiceVm>(entity);
    }
}
