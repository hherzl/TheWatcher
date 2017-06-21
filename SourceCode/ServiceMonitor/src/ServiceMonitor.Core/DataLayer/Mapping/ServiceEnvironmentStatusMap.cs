using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceEnvironmentStatusMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ServiceEnvironmentStatus>();

            entity.ToTable("ServiceEnvironmentStatus");

            entity.HasKey(p => p.ServiceEnvironmentStatusID);

            entity.Property(p => p.ServiceEnvironmentStatusID).UseSqlServerIdentityColumn();
        }
    }
}
