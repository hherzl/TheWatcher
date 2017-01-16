using System.Collections.Generic;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Contracts
{
    public interface IServiceWatcherRepository : IRepository<ServiceWatcher>
    {
        IEnumerable<ServiceWatcherItem> GetServiceWatcherItems();
    }
}
