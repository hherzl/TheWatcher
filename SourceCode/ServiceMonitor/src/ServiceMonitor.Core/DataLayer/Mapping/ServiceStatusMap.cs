using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceStatusMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ServiceStatus>();

            entity.ToTable("ServiceStatus");

            entity.HasKey(p => p.ServiceStatusID);

            entity.Property(p => p.ServiceStatusID).UseSqlServerIdentityColumn();
        }
    }
}
