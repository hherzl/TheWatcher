using System;

namespace ServiceMonitor.Core.EntityLayer
{
    public class Owner
    {
        public Owner()
        {
        }

        public Owner(Int32? ownerID)
        {
            OwnerID = ownerID;
        }

        public Int32? OwnerID { get; set; }

        public String UserName { get; set; }

        public Int32? EmployeeID { get; set; }
    }
}
