namespace ServiceMonitor.Core.Domain
{
    public class ServiceEnvironment
    {
        public ServiceEnvironment()
        {
        }

        public ServiceEnvironment(short? id)
        {
            ID = id;
        }

        public short? ID { get; set; }

        public short? ServiceID { get; set; }

        public short? EnvironmentID { get; set; }

        public int? Interval { get; set; }

        public string Url { get; set; }

        public string Address { get; set; }

        public string ConnectionString { get; set; }

        public string Description { get; set; }

        public bool? Active { get; set; }
    }
}
