using System;

namespace ServiceMonitor.Core.Domain.DataContracts
{
    public class ServiceStatusDetailInfo
    {
        public int? ServiceEnvironmentStatusID { get; set; }

        public short? ServiceEnvironmentID { get; set; }

        public short? ServiceID { get; set; }

        public string ServiceName { get; set; }

        public string EnvironmentName { get; set; }

        public bool? Successful { get; set; }

        public int? WatchCount { get; set; }

        public DateTime? LastWatch { get; set; }
    }
}
