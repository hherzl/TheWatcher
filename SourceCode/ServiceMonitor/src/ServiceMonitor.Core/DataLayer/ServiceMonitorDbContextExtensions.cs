using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.DataLayer.Mapping;

namespace ServiceMonitor.Core.DataLayer
{
    public static class ServiceMonitorDbContextExtensions
    {
        public static ModelBuilder ApplyConfiguration(this ModelBuilder modelBuilder, IEntityMap entityMap)
        {
            entityMap.Map(modelBuilder);

            return modelBuilder;
        }
    }
}
