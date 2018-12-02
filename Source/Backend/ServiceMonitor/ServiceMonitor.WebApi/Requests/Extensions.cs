using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.WebApi.Requests
{
    public static class Extensions
    {
        public static ServiceEnvironmentStatusLog ToEntity(this ServiceEnvironmentStatusLogRequest request)
            => RequestMapper.ConfigMapper.Map<ServiceEnvironmentStatusLogRequest, ServiceEnvironmentStatusLog>(request);

        public static ServiceEnvironmentStatusLogRequest ToRequest(this ServiceEnvironmentStatusLog entity)
            => RequestMapper.ConfigMapper.Map<ServiceEnvironmentStatusLog, ServiceEnvironmentStatusLogRequest>(entity);
    }
}
