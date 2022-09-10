using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServiceMonitor.Core.Domain.Configurations
{
    public class ServiceWatcherConfiguration : IEntityTypeConfiguration<ServiceWatcher>
    {
        public void Configure(EntityTypeBuilder<ServiceWatcher> builder)
        {
            // Mapping for table
            builder.ToTable("ServiceWatcher", "dbo");

            // Set key for entity
            builder.HasKey(p => p.ID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.ID).UseSqlServerIdentityColumn();
        }
    }
}
