using System;

namespace ServiceMonitor
{
    public class ServiceStatusLog
    {
        public ServiceStatusLog()
        {
        }

        public Int32? ServiceID { get; set; }

        public String Target { get; set; }

        public String ActionName { get; set; }

        public Boolean? Success { get; set; }

        public String Message { get; set; }

        public String StackTrace { get; set; }
    }
}
