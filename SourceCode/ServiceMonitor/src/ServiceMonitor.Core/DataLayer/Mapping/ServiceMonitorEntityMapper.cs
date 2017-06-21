using System.Collections.Generic;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceMonitorEntityMapper : EntityMapper
    {
        public ServiceMonitorEntityMapper()
        {
            Mappings = new List<IEntityMap>()
            {
                new OwnerMap(),
                new ServiceCategoryMap(),
                new ServiceMap(),
                new ServiceEnvironmentMap(),
                new ServiceOwnerMap(),
                new ServiceEnvironmentStatusLogMap(),
                new ServiceEnvironmentStatusMap(),
                new ServiceUserMap(),
                new ServiceWatcherMap(),
                new UserMap(),
                new EnvironmentCategoryMap()
            };
        }
    }
}
