namespace ServiceMonitor.Core.Domain
{
    public class Service
    {
        public Service()
        {
        }

        public Service(short? id)
        {
            ID = id;
        }

        public short? ID { get; set; }

        public short? ServiceCategoryID { get; set; }

        public string Name { get; set; }
    }
}
