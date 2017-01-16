using System.Linq;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Repositories
{
    public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public OwnerRepository(ServiceMonitorDbContext dbContext)
            : base(dbContext)
        {
        }
        
        public override Owner Get(Owner entity)
        {
            return DbSet.FirstOrDefault(item => item.OwnerID == entity.OwnerID);
        }
    }
}
