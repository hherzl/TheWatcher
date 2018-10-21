namespace ServiceMonitor.Core.EntityLayer
{
    public class ServiceUser
    {
        public ServiceUser()
        {
        }

        public ServiceUser(int? serviceUserID)
        {
            ServiceUserID = serviceUserID;
        }

        public int? ServiceUserID { get; set; }

        public int? ServiceID { get; set; }

        public int? UserID { get; set; }
    }
}
