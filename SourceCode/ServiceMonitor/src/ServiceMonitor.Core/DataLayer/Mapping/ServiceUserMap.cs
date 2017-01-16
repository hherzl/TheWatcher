using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceUserMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ServiceUser>();

            entity.ToTable("ServiceUser");

            entity.HasKey(p => p.ServiceUserID);

            entity.Property(p => p.ServiceUserID).UseSqlServerIdentityColumn();
        }
    }
}
