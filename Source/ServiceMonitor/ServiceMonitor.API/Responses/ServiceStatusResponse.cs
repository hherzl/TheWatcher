using System;

namespace ServiceMonitor.API.Responses
{
    public class ServiceStatusResponse
    {
        public int? ServiceStatusID { get; set; }

        public int? ServiceID { get; set; }

        public bool? Success { get; set; }

        public int? WatchCount { get; set; }

        public DateTime? LastWatch { get; set; }
    }
}
