using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceWatcherMap : IEntityTypeConfiguration<ServiceWatcher>
    {
        public void Configure(EntityTypeBuilder<ServiceWatcher> builder)
        {
            builder.ToTable("ServiceWatcher");

            builder.HasKey(p => p.ServiceWatcherID);

            builder.Property(p => p.ServiceWatcherID).UseSqlServerIdentityColumn();
        }
    }
}
