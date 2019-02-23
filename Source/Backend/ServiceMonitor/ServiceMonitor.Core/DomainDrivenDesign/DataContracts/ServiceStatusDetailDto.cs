using System;

namespace ServiceMonitor.Core.DomainDrivenDesign.DataContracts
{
    public class ServiceStatusDetailDto
    {
        public ServiceStatusDetailDto()
        {
        }

        public int? ServiceEnvironmentStatusID { get; set; }

        public int? ServiceEnvironmentID { get; set; }

        public int? ServiceID { get; set; }

        public string ServiceName { get; set; }

        public string EnvironmentName { get; set; }

        public bool? Success { get; set; }

        public int? WatchCount { get; set; }

        public DateTime? LastWatch { get; set; }
    }
}
