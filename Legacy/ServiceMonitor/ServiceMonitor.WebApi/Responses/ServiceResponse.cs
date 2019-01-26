namespace ServiceMonitor.WebApi.Responses
{
    public class ServiceResponse
    {
        public int? ServiceID { get; set; }

        public int? ServiceCategoryID { get; set; }

        public string Name { get; set; }

        public int? Interval { get; set; }

        public string Url { get; set; }

        public string Address { get; set; }

        public string Connectionstring { get; set; }

        public string Description { get; set; }
    }
}
