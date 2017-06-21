using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceUserVmMapper
    {
        public static ServiceUser ToEntity(this ServiceUserVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceUserVm, ServiceUser>(viewModel);

        public static ServiceUserVm ToViewModel(this ServiceUser entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceUser, ServiceUserVm>(entity);
    }
}
