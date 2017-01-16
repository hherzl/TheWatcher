using System;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.ViewModels
{
    public class ServiceOwnerViewModel
    {
        public ServiceOwnerViewModel()
        {
        }
        
        public Int32? ServiceOwnerID { get; set; }
        
        public Int32? ServiceID { get; set; }
        
        public Int32? OwnerID { get; set; }
    }
    
    public static class ServiceOwnerViewModelMapper
    {
        public static ServiceOwner ToEntity(this ServiceOwnerViewModel viewModel)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceOwnerViewModel, ServiceOwner>(viewModel);
        }
        
        public static ServiceOwnerViewModel ToViewModel(this ServiceOwner entity)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceOwner, ServiceOwnerViewModel>(entity);
        }
    }
}
