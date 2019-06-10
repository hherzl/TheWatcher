namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public class User
    {
        public User()
        {
        }

        public User(int? id)
        {
            ID = id;
        }

        public int? ID { get; set; }

        public string UserName { get; set; }

        public int? EmployeeID { get; set; }
    }
}
