using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceEnvironmentStatusLogMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceEnvironmentStatusLog>(entity =>
            {
                entity.ToTable("ServiceEnvironmentStatusLog");

                entity.HasKey(p => p.ServiceEnvironmentStatusLogID);

                entity.Property(p => p.ServiceEnvironmentStatusLogID).UseSqlServerIdentityColumn();
            });
        }
    }
}
