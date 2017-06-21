using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.ViewModels
{
    public static class UserViewModelMapper
    {
        public static User ToEntity(this UserVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<UserVm, User>(viewModel);

        public static UserVm ToViewModel(this User entity)
            => ViewModelMapper.ConfigMapper.Map<User, UserVm>(entity);
    }
}
