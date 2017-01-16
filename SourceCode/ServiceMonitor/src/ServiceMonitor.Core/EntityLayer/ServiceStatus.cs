using System;

namespace ServiceMonitor.Core.EntityLayer
{
    public class ServiceStatus
    {
        public ServiceStatus()
        {
        }

        public ServiceStatus(Int32? serviceStatusID)
        {
            ServiceStatusID = serviceStatusID;
        }

        public Int32? ServiceStatusID { get; set; }

        public Int32? ServiceID { get; set; }

        public Boolean? Success { get; set; }

        public Int32? WatchCount { get; set; }

        public DateTime? LastWatch { get; set; }
    }
}
