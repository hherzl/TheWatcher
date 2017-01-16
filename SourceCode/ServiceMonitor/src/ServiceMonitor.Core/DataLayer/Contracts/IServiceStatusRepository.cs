using System;
using System.Collections.Generic;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Contracts
{
    public interface IServiceStatusRepository : IRepository<ServiceStatus>
    {
        ServiceStatus GetByService(Int32? serviceID);
        
        IEnumerable<ServiceStatusDetail> GetServiceStatusDetails();
    }
}
