using AutoMapper;
using ServiceMonitor.Core.DomainDrivenDesign;

namespace ServiceMonitor.WebAPI.Requests
{
#pragma warning disable CS1591
    public static class RequestMapper
    {
        static RequestMapper()
        {
            ConfigMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<ServiceEnvironmentStatusLog, ServiceEnvironmentStatusLogRequest>();

                config.CreateMap<ServiceEnvironmentStatusLogRequest, ServiceEnvironmentStatusLog>();
            }).CreateMapper();
        }

        public static IMapper ConfigMapper { get; }
#pragma warning restore CS1591
    }
}
