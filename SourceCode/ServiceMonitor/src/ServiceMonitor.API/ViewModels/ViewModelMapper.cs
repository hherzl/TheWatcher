using AutoMapper;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.ViewModels
{
    public static class ViewModelMapper
    {
        private static IMapper m_configMapper;

        static ViewModelMapper()
        {
            m_configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OwnerVm, Owner>();
                cfg.CreateMap<Owner, OwnerVm>();

                cfg.CreateMap<ServiceCategory, ServiceCategoryVm>();
                cfg.CreateMap<ServiceCategoryVm, ServiceCategory>();

                cfg.CreateMap<Service, ServiceVm>();
                cfg.CreateMap<ServiceVm, Service>();

                cfg.CreateMap<ServiceWatcher, ServiceWatcherVm>();
                cfg.CreateMap<ServiceWatcherVm, ServiceWatcher>();

                cfg.CreateMap<ServiceWatcherItemDto, ServiceWatcherItemVm>();
                cfg.CreateMap<ServiceWatcherItemVm, ServiceWatcherItemDto>();

                cfg.CreateMap<ServiceEnvironmentStatus, ServiceStatusVm>();
                cfg.CreateMap<ServiceStatusVm, ServiceEnvironmentStatus>();

                cfg.CreateMap<ServiceStatusDetailDto, ServiceStatusDetailVm>();
                cfg.CreateMap<ServiceStatusDetailVm, ServiceStatusDetailDto>();

                cfg.CreateMap<ServiceEnvironmentStatusLog, ServiceEnvironmentStatusLogVm>();
                cfg.CreateMap<ServiceEnvironmentStatusLogVm, ServiceEnvironmentStatusLog>();

                cfg.CreateMap<ServiceUser, ServiceUserVm>();
                cfg.CreateMap<ServiceUserVm, ServiceUser>();

                cfg.CreateMap<Owner, OwnerVm>();
                cfg.CreateMap<OwnerVm, Owner>();

                cfg.CreateMap<ServiceOwner, ServiceOwnerVm>();
                cfg.CreateMap<ServiceOwnerVm, ServiceOwner>();

                cfg.CreateMap<User, UserVm>();
                cfg.CreateMap<UserVm, User>();
            }).CreateMapper();
        }

        public static IMapper ConfigMapper => m_configMapper;
    }
}
