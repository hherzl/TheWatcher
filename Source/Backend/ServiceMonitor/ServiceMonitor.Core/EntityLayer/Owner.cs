namespace ServiceMonitor.Core.EntityLayer
{
    public class Owner
    {
        public Owner()
        {
        }

        public Owner(int? ownerID)
        {
            OwnerID = ownerID;
        }

        public int? OwnerID { get; set; }

        public string UserName { get; set; }

        public int? EmployeeID { get; set; }
    }
}
