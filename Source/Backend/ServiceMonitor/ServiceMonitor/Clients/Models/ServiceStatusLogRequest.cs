namespace ServiceMonitor.Clients.Models
{
    public class ServiceStatusLogRequest
    {
        public int? ServiceID { get; set; }

        public int? ServiceEnvironmentID { get; set; }

        public string Target { get; set; }

        public string ActionName { get; set; }

        public bool? Success { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }
    }
}
