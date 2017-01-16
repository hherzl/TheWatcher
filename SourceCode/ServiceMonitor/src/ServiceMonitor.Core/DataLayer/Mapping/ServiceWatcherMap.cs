using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceWatcherMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ServiceWatcher>();

            entity.ToTable("ServiceWatcher");

            entity.HasKey(p => p.ServiceWatcherID);

            entity.Property(p => p.ServiceWatcherID).UseSqlServerIdentityColumn();
        }
    }
}
