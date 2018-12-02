using System;

namespace ServiceMonitor.WebApi.Responses
{
    public class ServiceStatusDetailResponse
    {
        public int? ServiceStatusID { get; set; }

        public int? ServiceID { get; set; }

        public string ServiceName { get; set; }

        public bool? Success { get; set; }

        public int? WatchCount { get; set; }

        public DateTime? LastWatch { get; set; }
    }
}
