using System.Collections.Generic;
using System.Linq;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Repositories
{
    public class ServiceWatcherRepository : Repository<ServiceWatcher>, IServiceWatcherRepository
    {
        public ServiceWatcherRepository(ServiceMonitorDbContext dbContext)
            : base(dbContext)
        {
        }
        
        public IEnumerable<ServiceWatcherItem> GetServiceWatcherItems()
        {
            return
                from serviceWatcher in GetAll()
                join service in DbContext.Set<Service>() on serviceWatcher.ServiceID equals service.ServiceID
                where service.Active == true
                select new ServiceWatcherItem
                {
                    ServiceID = service.ServiceID,
                    ServiceName = service.Name,
                    Interval = service.Interval,
                    Url = service.Url,
                    Address = service.Address,
                    ConnectionString = service.ConnectionString,
                    TypeName = serviceWatcher.TypeName
                };
        }
        
        public override ServiceWatcher Get(ServiceWatcher entity)
        {
            return DbSet.FirstOrDefault(item => item.ServiceWatcherID == entity.ServiceWatcherID);
        }
    }
}
