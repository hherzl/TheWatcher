using System;

namespace ServiceMonitor.Core.EntityLayer
{
    public class ServiceEnvironment
    {
        public ServiceEnvironment()
        {
        }

        public ServiceEnvironment(Int32? serviceEnvironmentID)
        {
            ServiceEnvironmentID = serviceEnvironmentID;
        }

        public Int32? ServiceEnvironmentID { get; set; }

        public Int32? ServiceID { get; set; }

        public Int32? EnvironmentCategoryID { get; set; }

        public Int32? Interval { get; set; }

        public String Url { get; set; }

        public String Address { get; set; }

        public String ConnectionString { get; set; }

        public String Description { get; set; }

        public Boolean? Active { get; set; }
    }
}
