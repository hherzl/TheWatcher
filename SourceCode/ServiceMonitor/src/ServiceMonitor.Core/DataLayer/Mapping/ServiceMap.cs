using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Service>();

            entity.ToTable("Service");

            entity.HasKey(p => p.ServiceID);

            entity.Property(p => p.ServiceID).UseSqlServerIdentityColumn();
        }
    }
}
