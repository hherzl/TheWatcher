using System;

namespace ServiceMonitor.Core.EntityLayer
{
    public class User
    {
        public User()
        {
        }

        public User(Int32? userID)
        {
            UserID = userID;
        }

        public Int32? UserID { get; set; }

        public String UserName { get; set; }

        public Int32? EmployeeID { get; set; }
    }
}
