using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServiceMonitor.Core.Domain.Configurations
{
    public class ServiceEnvironmentStatusConfiguration : IEntityTypeConfiguration<ServiceEnvironmentStatus>
    {
        public void Configure(EntityTypeBuilder<ServiceEnvironmentStatus> builder)
        {
            // Mapping for table
            builder.ToTable("ServiceEnvironmentStatus", "dbo");

            // Set key for entity
            builder.HasKey(p => p.ID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.ID).UseSqlServerIdentityColumn();
        }
    }
}
