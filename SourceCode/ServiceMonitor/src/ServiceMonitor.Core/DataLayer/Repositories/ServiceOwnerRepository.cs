using System.Linq;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Repositories
{
    public class ServiceOwnerRepository : Repository<ServiceOwner>, IServiceOwnerRepository
    {
        public ServiceOwnerRepository(ServiceMonitorDbContext dbContext)
            : base(dbContext)
        {
        }
        
        public override ServiceOwner Get(ServiceOwner entity)
        {
            return DbSet.FirstOrDefault(item => item.ServiceOwnerID == entity.ServiceOwnerID);
        }
    }
}
