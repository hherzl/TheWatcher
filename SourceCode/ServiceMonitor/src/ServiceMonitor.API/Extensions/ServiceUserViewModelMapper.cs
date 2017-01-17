using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceUserViewModelMapper
    {
        public static ServiceUser ToEntity(this ServiceUserViewModel viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceUserViewModel, ServiceUser>(viewModel);

        public static ServiceUserViewModel ToViewModel(this ServiceUser entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceUser, ServiceUserViewModel>(entity);
    }
}
