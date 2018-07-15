using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.HasKey(p => p.ServiceID);

                entity.Property(p => p.ServiceID).UseSqlServerIdentityColumn();
            });
        }
    }
}
