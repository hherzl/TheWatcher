namespace ServiceMonitor.API.Responses
{
    public class ServiceWatcherItemResponse
    {
        public int? ServiceID { get; set; }

        public string ServiceName { get; set; }

        public int? Interval { get; set; }

        public string Url { get; set; }

        public string Address { get; set; }

        public string Connectionstring { get; set; }

        public string TypeName { get; set; }
    }
}
