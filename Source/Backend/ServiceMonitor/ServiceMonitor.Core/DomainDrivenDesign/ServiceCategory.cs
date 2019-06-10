namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public class ServiceCategory
    {
        public ServiceCategory()
        {
        }

        public ServiceCategory(int? id)
        {
            ID = id;
        }

        public int? ID { get; set; }

        public string Name { get; set; }
    }
}
