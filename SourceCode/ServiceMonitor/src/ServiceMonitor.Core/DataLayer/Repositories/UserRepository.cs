using System;
using System.Linq;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ServiceMonitorDbContext dbContext)
            : base(dbContext)
        {
        }
        
        public User GetByUserName(String userName)
        {
            return DbSet.FirstOrDefault(item => item.UserName == userName);
        }
        
        public override User Get(User entity)
        {
            return DbSet.FirstOrDefault(item => item.UserID == entity.UserID);
        }
    }
}
