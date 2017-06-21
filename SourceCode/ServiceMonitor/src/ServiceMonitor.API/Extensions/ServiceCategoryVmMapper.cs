using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceCategoryVmMapper
    {
        public static ServiceCategory ToEntity(this ServiceCategoryVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceCategoryVm, ServiceCategory>(viewModel);

        public static ServiceCategoryVm ToViewModel(this ServiceCategory entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceCategory, ServiceCategoryVm>(entity);
    }
}
