namespace ServiceMonitor.Clients.DataContracts
{
    public class ServiceStatusLogRequest
    {
        public int? ServiceID { get; set; }

        public int? ServiceEnvironmentID { get; set; }

        public string Target { get; set; }

        public string ActionName { get; set; }

        public bool? Successful { get; set; }

        public string ShortMessage { get; set; }

        public string FullMessage { get; set; }
    }
}
