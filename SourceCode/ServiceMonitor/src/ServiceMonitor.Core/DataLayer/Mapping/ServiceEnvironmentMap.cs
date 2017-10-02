using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceEnvironmentMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceEnvironment>(entity =>
            {
                entity.ToTable("ServiceEnvironment");

                entity.HasKey(p => p.ServiceEnvironmentID);

                entity.Property(p => p.ServiceEnvironmentID).UseSqlServerIdentityColumn();
            });
        }
    }
}
