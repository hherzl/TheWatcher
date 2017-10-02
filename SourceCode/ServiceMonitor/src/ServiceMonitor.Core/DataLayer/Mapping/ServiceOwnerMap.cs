using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceOwnerMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceOwner>(entity =>
            {
                entity.ToTable("ServiceOwner");

                entity.HasKey(p => p.ServiceOwnerID);

                entity.Property(p => p.ServiceOwnerID).UseSqlServerIdentityColumn();
            });
        }
    }
}
