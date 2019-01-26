namespace ServiceMonitor.Core.EntityLayer
{
    public class ServiceEnvironment
    {
        public ServiceEnvironment()
        {
        }

        public ServiceEnvironment(int? serviceEnvironmentID)
        {
            ServiceEnvironmentID = serviceEnvironmentID;
        }

        public int? ServiceEnvironmentID { get; set; }

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
