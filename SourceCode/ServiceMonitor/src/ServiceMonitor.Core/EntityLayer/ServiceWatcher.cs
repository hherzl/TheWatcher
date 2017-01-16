using System;

namespace ServiceMonitor.Core.EntityLayer
{
    public class ServiceWatcher
    {
        public ServiceWatcher()
        {
        }

        public ServiceWatcher(Int32? serviceWatcherID)
        {
            ServiceWatcherID = serviceWatcherID;
        }

        public Int32? ServiceWatcherID { get; set; }

        public Int32? ServiceID { get; set; }

        public String TypeName { get; set; }
    }
}
