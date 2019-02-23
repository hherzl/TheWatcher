namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public class ServiceOwner
    {
        public ServiceOwner()
        {
        }

        public ServiceOwner(int? serviceOwnerID)
        {
            ServiceOwnerID = serviceOwnerID;
        }

        public int? ServiceOwnerID { get; set; }

        public int? ServiceID { get; set; }

        public int? OwnerID { get; set; }
    }
}
