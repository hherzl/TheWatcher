using System.Linq;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Repositories
{
    public class ServiceCategoryRepository : Repository<ServiceCategory>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(ServiceMonitorDbContext dbContext)
            : base(dbContext)
        {
        }
        
        public override ServiceCategory Get(ServiceCategory entity)
        {
            return DbSet.FirstOrDefault(item => item.ServiceCategoryID == entity.ServiceCategoryID);
        }
    }
}
