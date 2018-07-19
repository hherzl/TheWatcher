using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.API.ViewModels
{
    public static class Extensions
    {
        public static Owner ToEntity(this OwnerVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<OwnerVm, Owner>(viewModel);

        public static OwnerVm ToViewModel(this Owner entity)
            => ViewModelMapper.ConfigMapper.Map<Owner, OwnerVm>(entity);

        public static ServiceCategory ToEntity(this ServiceCategoryVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceCategoryVm, ServiceCategory>(viewModel);

        public static ServiceCategoryVm ToViewModel(this ServiceCategory entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceCategory, ServiceCategoryVm>(entity);

        public static ServiceOwner ToEntity(this ServiceOwnerVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceOwnerVm, ServiceOwner>(viewModel);

        public static ServiceOwnerVm ToViewModel(this ServiceOwner entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceOwner, ServiceOwnerVm>(entity);

        public static ServiceEnvironmentStatus ToEntity(this ServiceStatusVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatusVm, ServiceEnvironmentStatus>(viewModel);

        public static ServiceStatusVm ToViewModel(this ServiceEnvironmentStatus entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceEnvironmentStatus, ServiceStatusVm>(entity);

        public static ServiceStatusDetailDto ToEntity(this ServiceStatusDetailVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatusDetailVm, ServiceStatusDetailDto>(viewModel);

        public static ServiceStatusDetailVm ToViewModel(this ServiceStatusDetailDto entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatusDetailDto, ServiceStatusDetailVm>(entity);

        public static ServiceEnvironmentStatusLog ToEntity(this ServiceEnvironmentStatusLogVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceEnvironmentStatusLogVm, ServiceEnvironmentStatusLog>(viewModel);

        public static ServiceEnvironmentStatusLogVm ToViewModel(this ServiceEnvironmentStatusLog entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceEnvironmentStatusLog, ServiceEnvironmentStatusLogVm>(entity);

        public static ServiceUser ToEntity(this ServiceUserVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceUserVm, ServiceUser>(viewModel);

        public static ServiceUserVm ToViewModel(this ServiceUser entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceUser, ServiceUserVm>(entity);

        public static Service ToEntity(this ServiceVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceVm, Service>(viewModel);

        public static ServiceVm ToViewModel(this Service entity)
            => ViewModelMapper.ConfigMapper.Map<Service, ServiceVm>(entity);

        public static ServiceWatcherItemDto ToEntity(this ServiceWatcherItemVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcherItemVm, ServiceWatcherItemDto>(viewModel);

        public static ServiceWatcherItemVm ToViewModel(this ServiceWatcherItemDto entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcherItemDto, ServiceWatcherItemVm>(entity);

        public static ServiceWatcher ToEntity(this ServiceWatcherVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcherVm, ServiceWatcher>(viewModel);

        public static ServiceWatcherVm ToViewModel(this ServiceWatcher entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcher, ServiceWatcherVm>(entity);

        public static User ToEntity(this UserVm viewModel)
            => ViewModelMapper.ConfigMapper.Map<UserVm, User>(viewModel);

        public static UserVm ToViewModel(this User entity)
            => ViewModelMapper.ConfigMapper.Map<User, UserVm>(entity);
    }
}
