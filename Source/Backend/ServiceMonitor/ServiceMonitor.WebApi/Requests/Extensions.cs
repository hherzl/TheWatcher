using ServiceMonitor.Core.DomainDrivenDesign;

namespace ServiceMonitor.WebAPI.Requests
{
#pragma warning disable CS1591
    public static class Extensions
    {
        public static ServiceEnvironmentStatusLog ToEntity(this ServiceEnvironmentStatusLogRequest request)
            => RequestMapper.ConfigMapper.Map<ServiceEnvironmentStatusLogRequest, ServiceEnvironmentStatusLog>(request);

        public static ServiceEnvironmentStatusLogRequest ToRequest(this ServiceEnvironmentStatusLog entity)
            => RequestMapper.ConfigMapper.Map<ServiceEnvironmentStatusLog, ServiceEnvironmentStatusLogRequest>(entity);
    }
#pragma warning restore CS1591
}
