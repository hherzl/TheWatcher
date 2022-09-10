namespace ServiceMonitor.Core.Domain
{
    public class ServiceCategory
    {
        public ServiceCategory()
        {
        }

        public ServiceCategory(short? id)
        {
            ID = id;
        }

        public short? ID { get; set; }

        public string Name { get; set; }
    }
}
