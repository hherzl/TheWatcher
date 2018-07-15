using System;

namespace ServiceMonitor.API.ViewModels
{
    public class ServiceStatusVm
    {
        public int? ServiceStatusID { get; set; }

        public int? ServiceID { get; set; }

        public bool? Success { get; set; }

        public int? WatchCount { get; set; }

        public DateTime? LastWatch { get; set; }
    }
}
