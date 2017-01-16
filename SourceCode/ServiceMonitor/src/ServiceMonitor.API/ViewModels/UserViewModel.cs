using System;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
        }

        public Int32? UserID { get; set; }

        public String UserName { get; set; }

        public Int32? EmployeeID { get; set; }
    }

    public static class UserViewModelMapper
    {
        public static User ToEntity(this UserViewModel viewModel)
        {
            return ViewModelMapper.ConfigMapper.Map<UserViewModel, User>(viewModel);
        }

        public static UserViewModel ToViewModel(this User entity)
        {
            return ViewModelMapper.ConfigMapper.Map<User, UserViewModel>(entity);
        }
    }
}
