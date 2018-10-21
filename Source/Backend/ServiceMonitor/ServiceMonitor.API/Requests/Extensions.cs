using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.API.Requests
{
    public static class Extensions
    {
        public static ServiceEnvironmentStatusLog ToEntity(this ServiceEnvironmentStatusLogRequest viewModel)
            => RequestMapper.ConfigMapper.Map<ServiceEnvironmentStatusLogRequest, ServiceEnvironmentStatusLog>(viewModel);

        public static ServiceEnvironmentStatusLogRequest ToRequestModel(this ServiceEnvironmentStatusLog entity)
            => RequestMapper.ConfigMapper.Map<ServiceEnvironmentStatusLog, ServiceEnvironmentStatusLogRequest>(entity);
    }
}
