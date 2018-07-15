namespace ServiceMonitor.Core.EntityLayer
{
    public class User
    {
        public User()
        {
        }

        public User(int? userID)
        {
            UserID = userID;
        }

        public int? UserID { get; set; }

        public string UserName { get; set; }

        public int? EmployeeID { get; set; }
    }
}
