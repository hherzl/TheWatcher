using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class OwnerVmMapper
    {
        public static Owner ToEntity(this OwnerVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<OwnerVm, Owner>(viewModel);

        public static OwnerVm ToViewModel(this Owner entity)
            => ViewModelMapper.ConfigMapper.Map<Owner, OwnerVm>(entity);
    }
}
