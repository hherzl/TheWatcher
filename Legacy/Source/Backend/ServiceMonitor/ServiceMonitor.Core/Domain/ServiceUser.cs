using System;

namespace ServiceMonitor.Core.Domain
{
    public class ServiceUser
    {
        public ServiceUser()
        {
        }

        public ServiceUser(short? id)
        {
            ID = id;
        }

        public short? ID { get; set; }

        public short? ServiceID { get; set; }

        public Guid? UserID { get; set; }
    }
}
