using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Extensions
{
    public static class ServiceOwnerViewModelMapper
    {
        public static ServiceOwner ToEntity(this ServiceOwnerViewModel viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceOwnerViewModel, ServiceOwner>(viewModel);

        public static ServiceOwnerViewModel ToViewModel(this ServiceOwner entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceOwner, ServiceOwnerViewModel>(entity);
    }
}
