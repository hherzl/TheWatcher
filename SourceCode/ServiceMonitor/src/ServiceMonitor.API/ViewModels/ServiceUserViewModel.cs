using System;

namespace ServiceMonitor.ViewModels
{
    public class ServiceUserViewModel
    {
        public ServiceUserViewModel()
        {
        }

        public Int32? ServiceUserID { get; set; }

        public Int32? ServiceID { get; set; }

        public Int32? UserID { get; set; }
    }
}
