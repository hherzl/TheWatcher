namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public class ServiceEnvironment
    {
        public ServiceEnvironment()
        {
        }

        public ServiceEnvironment(int? id)
        {
            ID = id;
        }

        public int? ID { get; set; }

        public int? ServiceID { get; set; }

        public int? EnvironmentCategoryID { get; set; }

        public int? Interval { get; set; }

        public string Url { get; set; }

        public string Address { get; set; }

        public string ConnectionString { get; set; }

        public string Description { get; set; }

        public bool? Active { get; set; }
    }
}
