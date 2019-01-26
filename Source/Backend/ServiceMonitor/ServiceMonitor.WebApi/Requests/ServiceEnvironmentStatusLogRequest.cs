using System;

namespace ServiceMonitor.WebAPI.Requests
{
    public class ServiceEnvironmentStatusLogRequest
    {
        public int? ServiceEnvironmentStatusLogID { get; set; }

        public int? ServiceEnvironmentStatusID { get; set; }

        public int? ServiceEnvironmentID { get; set; }

        public string Target { get; set; }

        public string ActionName { get; set; }

        public bool? Success { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public DateTime? Date { get; set; }
    }
}
