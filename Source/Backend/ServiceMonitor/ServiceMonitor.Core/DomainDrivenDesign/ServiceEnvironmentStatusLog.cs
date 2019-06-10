using System;

namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public class ServiceEnvironmentStatusLog
    {
        public ServiceEnvironmentStatusLog()
        {
        }

        public ServiceEnvironmentStatusLog(int? serviceEnvironmentStatusLogID)
        {
            ID = serviceEnvironmentStatusLogID;
        }

        public int? ID { get; set; }

        public int? ServiceEnvironmentStatusID { get; set; }

        public string Target { get; set; }

        public string ActionName { get; set; }

        public bool? Success { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public DateTime? Date { get; set; }
    }
}
