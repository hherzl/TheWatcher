using System;

namespace ServiceMonitor.API.ViewModels
{
    public class ServiceOwnerVm
    {
        public Int32? ServiceOwnerID { get; set; }

        public Int32? ServiceID { get; set; }

        public Int32? OwnerID { get; set; }
    }
}
