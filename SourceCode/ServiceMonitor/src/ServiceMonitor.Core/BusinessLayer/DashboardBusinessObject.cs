using System;
using System.Collections.Generic;
using System.Linq;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Core.DataLayer;
using ServiceMonitor.Core.DataLayer.Contracts;
using ServiceMonitor.Core.DataLayer.DataContracts;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.BusinessLayer
{
    public partial class DashboardBusinessObject : IDashboardBusinessObject
    {
        private IDashboardUow DashboardUow;

        public DashboardBusinessObject(ServiceMonitorDbContext dbContext)
        {
            DashboardUow = new DashboardUow(dbContext);
        }

        public void Dispose()
        {
            DashboardUow?.Dispose();
        }

        public IEnumerable<ServiceWatcherItem> GetActiveServiceWatcherItems()
        {
            return DashboardUow.ServiceWatcherRepository.GetServiceWatcherItems();
        }

        public IEnumerable<ServiceStatusDetail> GetServiceStatuses(String userName)
        {
            var user = DashboardUow.UserRepository.GetByUserName(userName);

            var servicesToWatch = DashboardUow.ServiceUserRepository.GetByUser(user.UserID).Select(item => item.ServiceID).ToList();

            return DashboardUow.ServiceStatusRepository.GetServiceStatusDetails().Where(item => servicesToWatch.Contains(item.ServiceID));
        }

        public ServiceStatus GetServiceStatus(ServiceStatus entity)
        {
            return DashboardUow.ServiceStatusRepository.Get(new ServiceStatus { ServiceStatusID = entity.ServiceStatusID });
        }
    }
}
