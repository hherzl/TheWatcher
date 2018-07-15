using System;

namespace ServiceMonitor.Core.EntityLayer
{
    public class ServiceEnvironmentStatusLog
    {
        public ServiceEnvironmentStatusLog()
        {
        }

        public ServiceEnvironmentStatusLog(Int32? serviceEnvironmentStatusLogID)
        {
            ServiceEnvironmentStatusLogID = serviceEnvironmentStatusLogID;
        }

        public Int32? ServiceEnvironmentStatusLogID { get; set; }

        public Int32? ServiceEnvironmentStatusID { get; set; }

        public String Target { get; set; }

        public String ActionName { get; set; }

        public Boolean? Success { get; set; }

        public String Message { get; set; }

        public String StackTrace { get; set; }

        public DateTime? Date { get; set; }
    }
}
