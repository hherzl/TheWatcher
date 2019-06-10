namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public class Service
    {
        public Service()
        {
        }

        public Service(int? id)
        {
            ID = id;
        }

        public int? ID { get; set; }

        public int? ServiceCategoryID { get; set; }

        public string Name { get; set; }
    }
}
