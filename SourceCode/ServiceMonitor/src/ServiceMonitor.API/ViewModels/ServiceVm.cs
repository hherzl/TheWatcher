using System;

namespace ServiceMonitor.ViewModels
{
    public class ServiceVm
    {
        public ServiceVm()
        {
        }

        public Int32? ServiceID { get; set; }

        public Int32? ServiceCategoryID { get; set; }

        public String Name { get; set; }

        public Int32? Interval { get; set; }

        public String Url { get; set; }

        public String Address { get; set; }

        public String ConnectionString { get; set; }

        public String Description { get; set; }
    }
}
