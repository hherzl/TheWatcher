using System;

namespace ServiceMonitor.Core.EntityLayer
{
    public class ServiceUser
    {
        public ServiceUser()
        {
        }

        public ServiceUser(Int32? serviceUserID)
        {
            ServiceUserID = serviceUserID;
        }

        public Int32? ServiceUserID { get; set; }

        public Int32? ServiceID { get; set; }

        public Int32? UserID { get; set; }
    }
}
