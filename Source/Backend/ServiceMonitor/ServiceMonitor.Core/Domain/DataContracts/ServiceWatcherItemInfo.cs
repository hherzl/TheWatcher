namespace ServiceMonitor.Core.Domain.DataContracts
{
    public class ServiceWatcherItemInfo
    {
        public int? ServiceID { get; set; }

        public int? ServiceEnvironmentID { get; set; }

        public string Environment { get; set; }

        public string ServiceName { get; set; }

        public int? Interval { get; set; }

        public string Url { get; set; }

        public string Address { get; set; }

        public string ConnectionString { get; set; }

        public string TypeName { get; set; }
    }
}
