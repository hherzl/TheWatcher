using ServiceMonitor.Core.Domain;

namespace ServiceMonitor.WebAPI.Requests
{
#pragma warning disable CS1591
    public static class Extensions
    {
        public static ServiceEnvironmentStatusLog ToEntity(this PostServiceEnvironmentStatusLogRequest request)
            => RequestMapper.ConfigMapper.Map<PostServiceEnvironmentStatusLogRequest, ServiceEnvironmentStatusLog>(request);
    }
#pragma warning restore CS1591
}
