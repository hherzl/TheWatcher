using System;

namespace ServiceMonitor.ViewModels
{
    public class ServiceOwnerViewModel
    {
        public ServiceOwnerViewModel()
        {
        }

        public Int32? ServiceOwnerID { get; set; }

        public Int32? ServiceID { get; set; }

        public Int32? OwnerID { get; set; }
    }
}
