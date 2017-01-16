using System;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.ViewModels
{
    public class OwnerViewModel
    {
        public OwnerViewModel()
        {
        }

        public Int32? OwnerID { get; set; }

        public String UserName { get; set; }
    }

    public static class OwnerViewModelMapper
    {
        public static Owner ToEntity(this OwnerViewModel viewModel)
        {
            return ViewModelMapper.ConfigMapper.Map<OwnerViewModel, Owner>(viewModel);
        }

        public static OwnerViewModel ToViewModel(this Owner entity)
        {
            return ViewModelMapper.ConfigMapper.Map<Owner, OwnerViewModel>(entity);
        }
    }
}
