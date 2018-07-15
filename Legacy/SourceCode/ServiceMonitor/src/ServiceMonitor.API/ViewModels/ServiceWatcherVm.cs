using System;

namespace ServiceMonitor.API.ViewModels
{
    public class ServiceWatcherVm
    {
        public Int32? ServiceWatcherID { get; set; }

        public Int32? ServiceID { get; set; }

        public String TypeName { get; set; }
    }
}
