using System;
using System.Linq;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Repositories
{
    public class ServiceStatusLogRepository : Repository<ServiceStatusLog>, IServiceStatusLogRepository
    {
        public ServiceStatusLogRepository(ServiceMonitorDbContext dbContext)
            : base(dbContext)
        {
        }

        public override ServiceStatusLog Get(ServiceStatusLog entity)
        {
            return DbSet.FirstOrDefault(item => item.ServiceStatusLogID == entity.ServiceStatusLogID);
        }

        public override void Add(ServiceStatusLog entity)
        {
            if (!entity.Date.HasValue)
            {
                entity.Date = DateTime.Now;
            }

            base.Add(entity);
        }
    }
}
