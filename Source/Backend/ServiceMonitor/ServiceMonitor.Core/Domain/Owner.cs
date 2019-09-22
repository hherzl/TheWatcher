namespace ServiceMonitor.Core.Domain
{
    public class Owner
    {
        public Owner()
        {
        }

        public Owner(int? ownerID)
        {
            ID = ownerID;
        }

        public int? ID { get; set; }

        public string UserName { get; set; }

        public int? EmployeeID { get; set; }
    }
}
