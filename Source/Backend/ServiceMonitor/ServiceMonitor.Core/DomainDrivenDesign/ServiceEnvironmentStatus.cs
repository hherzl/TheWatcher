using System;

namespace ServiceMonitor.Core.DomainDrivenDesign
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

        public int? ServiceEnvironmentID { get; set; }

        public bool? Success { get; set; }

        public int? WatchCount { get; set; }

        public DateTime? LastWatch { get; set; }
    }
}
