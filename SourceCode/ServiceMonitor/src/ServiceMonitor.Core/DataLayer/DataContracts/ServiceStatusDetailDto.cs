using System;

namespace ServiceMonitor.Core.DataLayer.DataContracts
{
    public class ServiceStatusDetailDto
    {
        public ServiceStatusDetailDto()
        {
        }

        public Int32? ServiceEnvironmentStatusID { get; set; }

        public Int32? ServiceEnvironmentID { get; set; }

        public String ServiceName { get; set; }

        public Boolean? Success { get; set; }

        public Int32? WatchCount { get; set; }

        public DateTime? LastWatch { get; set; }
    }
}
