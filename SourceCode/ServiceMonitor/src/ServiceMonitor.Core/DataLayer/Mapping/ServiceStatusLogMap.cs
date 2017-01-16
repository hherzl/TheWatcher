using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceStatusLogMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ServiceStatusLog>();

            entity.ToTable("ServiceStatusLog");

            entity.HasKey(p => p.ServiceStatusLogID);

            entity.Property(p => p.ServiceStatusLogID).UseSqlServerIdentityColumn();
        }
    }
}
