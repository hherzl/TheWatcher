using System;

namespace ServiceMonitor.Core.EntityLayer
{
    public class ServiceStatusLog
    {
        public ServiceStatusLog()
        {
        }

        public ServiceStatusLog(Int32? serviceStatusLogID)
        {
            ServiceStatusLogID = serviceStatusLogID;
        }

        public Int32? ServiceStatusLogID { get; set; }

        public Int32? ServiceID { get; set; }

        public String Target { get; set; }

        public String ActionName { get; set; }

        public Boolean? Success { get; set; }

        public String Message { get; set; }

        public String StackTrace { get; set; }

        public DateTime? Date { get; set; }
    }
}
