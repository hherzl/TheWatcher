using System;

namespace ServiceMonitor.ViewModels
{
    public class ServiceUserVm
    {
        public ServiceUserVm()
        {
        }

        public Int32? ServiceUserID { get; set; }

        public Int32? ServiceID { get; set; }

        public Int32? UserID { get; set; }
    }
}
