namespace ServiceMonitor.Core.EntityLayer
{
    public class Service
    {
        public Service()
        {
        }

        public Service(int? serviceID)
        {
            ServiceID = serviceID;
        }

        public int? ServiceID { get; set; }

        public int? ServiceCategoryID { get; set; }

        public string Name { get; set; }
    }
}
