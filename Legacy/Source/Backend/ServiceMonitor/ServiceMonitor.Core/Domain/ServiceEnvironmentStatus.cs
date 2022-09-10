using System;

namespace ServiceMonitor.Core.Domain
{
    public class ServiceEnvironmentStatus
    {
        public ServiceEnvironmentStatus()
        {
        }

        public ServiceEnvironmentStatus(int? id)
        {
            ID = id;
        }

        public int? ID { get; set; }

        public short? ServiceEnvironmentID { get; set; }

        public bool? Successful { get; set; }

        public int? WatchCount { get; set; }

        public DateTime? LastWatch { get; set; }
    }
}
