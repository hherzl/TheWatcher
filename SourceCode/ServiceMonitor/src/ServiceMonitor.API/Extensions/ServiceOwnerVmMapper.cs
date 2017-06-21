using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceOwnerVmMapper
    {
        public static ServiceOwner ToEntity(this ServiceOwnerVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceOwnerVm, ServiceOwner>(viewModel);

        public static ServiceOwnerVm ToViewModel(this ServiceOwner entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceOwner, ServiceOwnerVm>(entity);
    }
}
