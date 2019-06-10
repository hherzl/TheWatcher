namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public class ServiceUser
    {
        public ServiceUser()
        {
        }

        public ServiceUser(int? id)
        {
            ID = id;
        }

        public int? ID { get; set; }

        public int? ServiceID { get; set; }

        public int? UserID { get; set; }
    }
}
