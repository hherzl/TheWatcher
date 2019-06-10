namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public class ServiceOwner
    {
        public ServiceOwner()
        {
        }

        public ServiceOwner(int? id)
        {
            ID = id;
        }

        public int? ID { get; set; }

        public int? ServiceID { get; set; }

        public int? OwnerID { get; set; }
    }
}
