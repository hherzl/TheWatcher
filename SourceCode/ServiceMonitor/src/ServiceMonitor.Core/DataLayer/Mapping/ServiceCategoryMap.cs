using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceCategoryMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ServiceCategory>();

            entity.ToTable("ServiceCategory");

            entity.HasKey(p => p.ServiceCategoryID);

            entity.Property(p => p.ServiceCategoryID).UseSqlServerIdentityColumn();
        }
    }
}
