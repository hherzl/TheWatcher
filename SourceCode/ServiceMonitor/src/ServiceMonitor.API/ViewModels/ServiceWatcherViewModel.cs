using System;

namespace ServiceMonitor.ViewModels
{
    public class ServiceWatcherViewModel
    {
        public ServiceWatcherViewModel()
        {
        }

        public Int32? ServiceWatcherID { get; set; }

        public Int32? ServiceID { get; set; }

        public String TypeName { get; set; }
    }
}
