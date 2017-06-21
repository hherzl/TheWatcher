using System;

namespace ServiceMonitor.ViewModels
{
    public class ServiceWatcherVm
    {
        public ServiceWatcherVm()
        {
        }

        public Int32? ServiceWatcherID { get; set; }

        public Int32? ServiceID { get; set; }

        public String TypeName { get; set; }
    }
}
