using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.ViewModels
{
    public static class UserViewModelMapper
    {
        public static User ToEntity(this UserViewModel viewModel) => ViewModelMapper.ConfigMapper.Map<UserViewModel, User>(viewModel);

        public static UserViewModel ToViewModel(this User entity) => ViewModelMapper.ConfigMapper.Map<User, UserViewModel>(entity);
    }
}
