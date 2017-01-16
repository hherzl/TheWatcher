using System;
using System.Collections.Generic;
using System.Linq;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Repositories
{
    public class ServiceStatusRepository : Repository<ServiceStatus>, IServiceStatusRepository
    {
        public ServiceStatusRepository(ServiceMonitorDbContext dbContext)
            : base(dbContext)
        {
        }
        
        public ServiceStatus GetByService(Int32? serviceID)
        {
            return DbSet.FirstOrDefault(item => item.ServiceID == serviceID);
        }
        
        public IEnumerable<ServiceStatusDetail> GetServiceStatusDetails()
        {
            return
                from serviceStatus in GetAll()
                join service in DbContext.Set<Service>() on serviceStatus.ServiceID equals service.ServiceID
                where service.Active == true
                select new ServiceStatusDetail
                {
                    ServiceStatusID = serviceStatus.ServiceStatusID,
                    ServiceID = serviceStatus.ServiceID,
                    ServiceName = service.Name,
                    Success = serviceStatus.Success,
                    WatchCount = serviceStatus.WatchCount,
                    LastWatch = serviceStatus.LastWatch
                };
        }
        
        public override ServiceStatus Get(ServiceStatus entity)
        {
            return DbSet.FirstOrDefault(item => item.ServiceStatusID == entity.ServiceStatusID);
        }
    }
}
