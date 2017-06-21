using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceEnvironmentStatusLogMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ServiceEnvironmentStatusLog>();

            entity.ToTable("ServiceEnvironmentStatusLog");

            entity.HasKey(p => p.ServiceEnvironmentStatusLogID);

            entity.Property(p => p.ServiceEnvironmentStatusLogID).UseSqlServerIdentityColumn();
        }
    }
}
