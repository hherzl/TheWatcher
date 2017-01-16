using System;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.ViewModels
{
    public class ServiceCategoryViewModel
    {
        public ServiceCategoryViewModel()
        {
        }

        public Int32? ServiceCategoryID { get; set; }

        public String Description { get; set; }
    }

    public static class ServiceCategoryViewModelMapper
    {
        public static ServiceCategory ToEntity(this ServiceCategoryViewModel viewModel)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceCategoryViewModel, ServiceCategory>(viewModel);
        }

        public static ServiceCategoryViewModel ToViewModel(this ServiceCategory entity)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceCategory, ServiceCategoryViewModel>(entity);
        }
    }
}
