using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class EnvironmentCategoryMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnvironmentCategory>(entity =>
            {
                entity.ToTable("EnvironmentCategory");

                entity.HasKey(p => p.EnvironmentCategoryID);

                entity.Property(p => p.EnvironmentCategoryID).UseSqlServerIdentityColumn();
            });
        }
    }
}
