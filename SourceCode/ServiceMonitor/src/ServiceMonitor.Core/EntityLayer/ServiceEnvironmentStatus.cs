using System;

namespace ServiceMonitor.Core.EntityLayer
{
    public class ServiceEnvironmentStatus
    {
        public ServiceEnvironmentStatus()
        {
        }

        public ServiceEnvironmentStatus(Int32? serviceEnvironmentStatusID)
        {
            ServiceEnvironmentStatusID = serviceEnvironmentStatusID;
        }

        public Int32? ServiceEnvironmentStatusID { get; set; }

        public Int32? ServiceEnvironmentID { get; set; }

        public Boolean? Success { get; set; }

        public Int32? WatchCount { get; set; }

        public DateTime? LastWatch { get; set; }
    }
}
