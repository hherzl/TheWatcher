using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class OwnerViewModelMapper
    {
        public static Owner ToEntity(this OwnerViewModel viewModel)
            => ViewModelMapper.ConfigMapper.Map<OwnerViewModel, Owner>(viewModel);

        public static OwnerViewModel ToViewModel(this Owner entity)
            => ViewModelMapper.ConfigMapper.Map<Owner, OwnerViewModel>(entity);
    }
}
