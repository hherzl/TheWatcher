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
                cfg.CreateMap<OwnerViewModel, Owner>();
                cfg.CreateMap<Owner, OwnerViewModel>();

                cfg.CreateMap<ServiceCategory, ServiceCategoryViewModel>();
                cfg.CreateMap<ServiceCategoryViewModel, ServiceCategory>();

                cfg.CreateMap<Service, ServiceViewModel>();
                cfg.CreateMap<ServiceViewModel, Service>();

                cfg.CreateMap<ServiceWatcher, ServiceWatcherViewModel>();
                cfg.CreateMap<ServiceWatcherViewModel, ServiceWatcher>();

                cfg.CreateMap<ServiceWatcherItem, ServiceWatcherItemViewModel>();
                cfg.CreateMap<ServiceWatcherItemViewModel, ServiceWatcherItem>();

                cfg.CreateMap<ServiceStatus, ServiceStatusViewModel>();
                cfg.CreateMap<ServiceStatusViewModel, ServiceStatus>();

                cfg.CreateMap<ServiceStatusDetail, ServiceStatusDetailViewModel>();
                cfg.CreateMap<ServiceStatusDetailViewModel, ServiceStatusDetail>();

                cfg.CreateMap<ServiceStatusLog, ServiceStatusLogViewModel>();
                cfg.CreateMap<ServiceStatusLogViewModel, ServiceStatusLog>();

                cfg.CreateMap<ServiceUser, ServiceUserViewModel>();
                cfg.CreateMap<ServiceUserViewModel, ServiceUser>();

                cfg.CreateMap<Owner, OwnerViewModel>();
                cfg.CreateMap<OwnerViewModel, Owner>();

                cfg.CreateMap<ServiceOwner, ServiceOwnerViewModel>();
                cfg.CreateMap<ServiceOwnerViewModel, ServiceOwner>();

                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();
            }).CreateMapper();
        }

        public static IMapper ConfigMapper
        {
            get
            {
                return m_configMapper;
            }
        }
    }
}
