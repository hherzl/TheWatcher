using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceCategoryViewModelMapper
    {
        public static ServiceCategory ToEntity(this ServiceCategoryViewModel viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceCategoryViewModel, ServiceCategory>(viewModel);

        public static ServiceCategoryViewModel ToViewModel(this ServiceCategory entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceCategory, ServiceCategoryViewModel>(entity);
    }
}
