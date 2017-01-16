using System;
using System.Collections.Generic;
using System.Linq;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Repositories
{
    public class ServiceUserRepository : Repository<ServiceUser>, IServiceUserRepository
    {
        public ServiceUserRepository(ServiceMonitorDbContext dbContext)
            : base(dbContext)
        {
        }
        
        public IEnumerable<ServiceUser> GetByUser(Int32? userID)
        {
            return DbSet.Where(item => item.UserID == userID);
        }
        
        public override ServiceUser Get(ServiceUser entity)
        {
            return DbSet.FirstOrDefault(item => item.ServiceUserID == entity.ServiceUserID);
        }
    }
}
