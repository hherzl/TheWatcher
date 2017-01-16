using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class OwnerMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Owner>();

            entity.ToTable("Owner");

            entity.HasKey(p => p.OwnerID);

            entity.Property(p => p.OwnerID).UseSqlServerIdentityColumn();
        }
    }
}
