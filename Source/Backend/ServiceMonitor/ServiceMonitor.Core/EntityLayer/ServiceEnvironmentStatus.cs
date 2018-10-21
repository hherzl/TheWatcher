using System;

namespace ServiceMonitor.Core.EntityLayer
{
    public class ServiceEnvironmentStatus
    {
        public ServiceEnvironmentStatus()
        {
        }

        public ServiceEnvironmentStatus(int? serviceEnvironmentStatusID)
        {
            ServiceEnvironmentStatusID = serviceEnvironmentStatusID;
        }

        public int? ServiceEnvironmentStatusID { get; set; }

        public int? ServiceEnvironmentID { get; set; }

        public bool? Success { get; set; }

        public int? WatchCount { get; set; }

        public DateTime? LastWatch { get; set; }
    }
}
