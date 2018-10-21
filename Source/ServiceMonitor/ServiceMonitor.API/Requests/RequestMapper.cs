using AutoMapper;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.API.Requests
{
    public static class RequestMapper
    {
        static RequestMapper()
        {
            ConfigMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ServiceEnvironmentStatusLog, ServiceEnvironmentStatusLogRequest>();
                cfg.CreateMap<ServiceEnvironmentStatusLogRequest, ServiceEnvironmentStatusLog>();
            }).CreateMapper();
        }

        public static IMapper ConfigMapper { get; }
    }
}
