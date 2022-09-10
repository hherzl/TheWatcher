using AutoMapper;
using ServiceMonitor.Core.Domain;

namespace ServiceMonitor.WebAPI.Requests
{
#pragma warning disable CS1591
    public static class RequestMapper
    {
        static RequestMapper()
        {
            ConfigMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<ServiceEnvironmentStatusLog, PostServiceEnvironmentStatusLogRequest>();

                config.CreateMap<PostServiceEnvironmentStatusLogRequest, ServiceEnvironmentStatusLog>();
            }).CreateMapper();
        }

        public static IMapper ConfigMapper { get; }
#pragma warning restore CS1591
    }
}
