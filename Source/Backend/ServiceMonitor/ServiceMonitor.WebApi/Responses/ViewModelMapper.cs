using AutoMapper;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.WebAPI.Responses
{
#pragma warning disable CS1591
    public static class ViewModelMapper
    {
        static ViewModelMapper()
        {
            ConfigMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OwnerResponse, Owner>();
                cfg.CreateMap<Owner, OwnerResponse>();

                cfg.CreateMap<ServiceCategory, ServiceCategoryResponse>();
                cfg.CreateMap<ServiceCategoryResponse, ServiceCategory>();

                cfg.CreateMap<Service, ServiceResponse>();
                cfg.CreateMap<ServiceResponse, Service>();

                cfg.CreateMap<ServiceWatcher, ServiceWatcherResponse>();
                cfg.CreateMap<ServiceWatcherResponse, ServiceWatcher>();

                cfg.CreateMap<ServiceWatcherItemDto, ServiceWatcherItemResponse>();
                cfg.CreateMap<ServiceWatcherItemResponse, ServiceWatcherItemDto>();

                cfg.CreateMap<ServiceEnvironmentStatus, ServiceStatusResponse>();
                cfg.CreateMap<ServiceStatusResponse, ServiceEnvironmentStatus>();

                cfg.CreateMap<ServiceStatusDetailDto, ServiceStatusDetailResponse>();
                cfg.CreateMap<ServiceStatusDetailResponse, ServiceStatusDetailDto>();

                cfg.CreateMap<ServiceUser, ServiceUserResponse>();
                cfg.CreateMap<ServiceUserResponse, ServiceUser>();

                cfg.CreateMap<Owner, OwnerResponse>();
                cfg.CreateMap<OwnerResponse, Owner>();

                cfg.CreateMap<ServiceOwner, ServiceOwnerResponse>();
                cfg.CreateMap<ServiceOwnerResponse, ServiceOwner>();

                cfg.CreateMap<User, UserResponse>();
                cfg.CreateMap<UserResponse, User>();
            }).CreateMapper();
        }

        public static IMapper ConfigMapper { get; }
    }
#pragma warning restore CS1591
}
