using System;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.ViewModels
{
    public class ServiceUserViewModel
    {
        public ServiceUserViewModel()
        {
        }

        public Int32? ServiceUserID { get; set; }

        public Int32? ServiceID { get; set; }

        public Int32? UserID { get; set; }
    }

    public static class ServiceUserViewModelMapper
    {
        public static ServiceUser ToEntity(this ServiceUserViewModel viewModel)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceUserViewModel, ServiceUser>(viewModel);
        }

        public static ServiceUserViewModel ToViewModel(this ServiceUser entity)
        {
            return ViewModelMapper.ConfigMapper.Map<ServiceUser, ServiceUserViewModel>(entity);
        }
    }
}
