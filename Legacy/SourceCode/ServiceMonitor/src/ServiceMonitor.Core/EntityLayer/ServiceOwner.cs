using System;

namespace ServiceMonitor.Core.EntityLayer
{
    public class ServiceOwner
    {
        public ServiceOwner()
        {
        }

        public ServiceOwner(Int32? serviceOwnerID)
        {
            ServiceOwnerID = serviceOwnerID;
        }

        public Int32? ServiceOwnerID { get; set; }

        public Int32? ServiceID { get; set; }

        public Int32? OwnerID { get; set; }
    }
}
