using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServiceMonitor.Core.Domain.Configurations
{
    public class WatcherConfiguration : IEntityTypeConfiguration<Watcher>
    {
        public void Configure(EntityTypeBuilder<Watcher> builder)
        {
            // Mapping for table
            builder.ToTable("Watcher", "dbo");

            // Set key for entity
            builder.HasKey(p => p.ID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.ID).UseSqlServerIdentityColumn();
        }
    }
}
