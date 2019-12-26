using System;

namespace ServiceMonitor.Core.Domain
{
    public class ServiceEnvironmentStatusLog
    {
        public ServiceEnvironmentStatusLog()
        {
        }

        public ServiceEnvironmentStatusLog(int? id)
        {
            ID = id;
        }

        public int? ID { get; set; }

        public int? ServiceEnvironmentStatusID { get; set; }

        public string Target { get; set; }

        public string ActionName { get; set; }

        public bool? Successful { get; set; }

        public string ShortMessage { get; set; }

        public string FullMessage { get; set; }

        public DateTime? Date { get; set; }
    }
}
