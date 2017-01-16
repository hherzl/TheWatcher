using System;

namespace ServiceMonitor.Core.DataLayer.DataContracts
{
    public class ServiceStatusDetail
    {
        public ServiceStatusDetail()
        {
        }

        public Int32? ServiceStatusID { get; set; }

        public Int32? ServiceID { get; set; }

        public String ServiceName { get; set; }

        public Boolean? Success { get; set; }

        public Int32? WatchCount { get; set; }

        public DateTime? LastWatch { get; set; }
    }
}
