using System;
using System.Collections.Generic;
using System.Linq;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(ServiceMonitorDbContext dbContext)
            : base(dbContext)
        {
        }
        
        public IEnumerable<Service> GetByServiceCategoryID(Int32? serviceCategoryID)
        {
            return DbSet.Where(item => item.ServiceCategoryID == serviceCategoryID);
        }

        public override Service Get(Service entity)
        {
            return DbSet.FirstOrDefault(item => item.ServiceID == entity.ServiceID);
        }
        
        public override void Add(Service entity)
        {
            if (!entity.Interval.HasValue)
            {
                entity.Interval = 5000;
            }

            entity.Active = true;

            base.Add(entity);
        }
    }
}
