using System;
using System.Collections.Generic;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.BusinessLayer.Contracts
{
    public interface IDashboardBusinessObject : IBusinessObject
    {
        IEnumerable<ServiceWatcherItem> GetActiveServiceWatcherItems();
        
        IEnumerable<ServiceStatusDetail> GetServiceStatuses(String userName);
        
        ServiceStatus GetServiceStatus(ServiceStatus entity);
    }
}
