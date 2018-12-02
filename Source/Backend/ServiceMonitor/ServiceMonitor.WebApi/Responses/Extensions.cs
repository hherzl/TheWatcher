using System.Net;
using Microsoft.AspNetCore.Mvc;
using ServiceMonitor.Core.BusinessLayer.Responses;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.WebApi.Responses
{
    public static class Extensions
    {
        public static IActionResult ToHttpResponse<TModel>(this IListResponse<TModel> response) where TModel : class
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NoContent;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this ISingleResponse<TModel> response) where TModel : class
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NotFound;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static Owner ToEntity(this OwnerResponse response)
            => ViewModelMapper.ConfigMapper.Map<OwnerResponse, Owner>(response);

        public static OwnerResponse ToRequestModel(this Owner entity)
            => ViewModelMapper.ConfigMapper.Map<Owner, OwnerResponse>(entity);

        public static ServiceCategory ToEntity(this ServiceCategoryResponse response)
            => ViewModelMapper.ConfigMapper.Map<ServiceCategoryResponse, ServiceCategory>(response);

        public static ServiceCategoryResponse ToRequestModel(this ServiceCategory entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceCategory, ServiceCategoryResponse>(entity);

        public static ServiceOwner ToEntity(this ServiceOwnerResponse response)
            => ViewModelMapper.ConfigMapper.Map<ServiceOwnerResponse, ServiceOwner>(response);

        public static ServiceOwnerResponse ToRequestModel(this ServiceOwner entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceOwner, ServiceOwnerResponse>(entity);

        public static ServiceEnvironmentStatus ToEntity(this ServiceStatusResponse response)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatusResponse, ServiceEnvironmentStatus>(response);

        public static ServiceStatusResponse ToRequestModel(this ServiceEnvironmentStatus entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceEnvironmentStatus, ServiceStatusResponse>(entity);

        public static ServiceStatusDetailDto ToEntity(this ServiceStatusDetailResponse response)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatusDetailResponse, ServiceStatusDetailDto>(response);

        public static ServiceStatusDetailResponse ToRequestModel(this ServiceStatusDetailDto entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceStatusDetailDto, ServiceStatusDetailResponse>(entity);

        public static ServiceUser ToEntity(this ServiceUserResponse response)
            => ViewModelMapper.ConfigMapper.Map<ServiceUserResponse, ServiceUser>(response);

        public static ServiceUserResponse ToRequestModel(this ServiceUser entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceUser, ServiceUserResponse>(entity);

        public static Service ToEntity(this ServiceResponse response)
            => ViewModelMapper.ConfigMapper.Map<ServiceResponse, Service>(response);

        public static ServiceResponse ToRequestModel(this Service entity)
            => ViewModelMapper.ConfigMapper.Map<Service, ServiceResponse>(entity);

        public static ServiceWatcherItemDto ToEntity(this ServiceWatcherItemResponse response)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcherItemResponse, ServiceWatcherItemDto>(response);

        public static ServiceWatcherItemResponse ToViewModel(this ServiceWatcherItemDto entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcherItemDto, ServiceWatcherItemResponse>(entity);

        public static ServiceWatcher ToEntity(this ServiceWatcherResponse response)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcherResponse, ServiceWatcher>(response);

        public static ServiceWatcherResponse ToViewModel(this ServiceWatcher entity)
            => ViewModelMapper.ConfigMapper.Map<ServiceWatcher, ServiceWatcherResponse>(entity);

        public static User ToEntity(this UserResponse response)
            => ViewModelMapper.ConfigMapper.Map<UserResponse, User>(response);

        public static UserResponse ToViewModel(this User entity)
            => ViewModelMapper.ConfigMapper.Map<User, UserResponse>(entity);
    }
}
