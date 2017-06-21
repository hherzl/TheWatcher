using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceEnvironmentMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ServiceEnvironment>();

            entity.ToTable("ServiceEnvironment");

            entity.HasKey(p => p.ServiceEnvironmentID);

            entity.Property(p => p.ServiceEnvironmentID).UseSqlServerIdentityColumn();
        }
    }
}
