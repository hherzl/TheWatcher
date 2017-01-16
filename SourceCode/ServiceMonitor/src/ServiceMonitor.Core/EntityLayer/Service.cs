using System;

namespace ServiceMonitor.Core.EntityLayer
{
    public class Service
    {
        public Service()
        {
        }

        public Service(Int32? serviceID)
        {
            ServiceID = serviceID;
        }

        public Int32? ServiceID { get; set; }

        public Int32? ServiceCategoryID { get; set; }

        public String Name { get; set; }

        public Int32? Interval { get; set; }

        public String Url { get; set; }

        public String Address { get; set; }

        public String ConnectionString { get; set; }

        public String Description { get; set; }

        public Boolean? Active { get; set; }
    }
}
