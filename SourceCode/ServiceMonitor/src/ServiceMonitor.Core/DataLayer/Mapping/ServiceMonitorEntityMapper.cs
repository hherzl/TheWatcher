using System.Collections.Generic;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceMonitorEntityMapper : EntityMapper
    {
        public ServiceMonitorEntityMapper()
        {
            Mappings = new List<IEntityMap>()
            {
                new OwnerMap() as IEntityMap,
                new ServiceCategoryMap() as IEntityMap,
                new ServiceMap() as IEntityMap,
                new ServiceOwnerMap() as IEntityMap,
                new ServiceStatusLogMap() as IEntityMap,
                new ServiceStatusMap() as IEntityMap,
                new ServiceUserMap() as IEntityMap,
                new ServiceWatcherMap() as IEntityMap,
                new UserMap() as IEntityMap
            };
        }
    }
}
