using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServiceMonitor.Core.Domain.Configurations
{
    public class ServiceEnvironmentStatusLogConfiguration : IEntityTypeConfiguration<ServiceEnvironmentStatusLog>
    {
        public void Configure(EntityTypeBuilder<ServiceEnvironmentStatusLog> builder)
        {
            // Mapping for table
            builder.ToTable("ServiceEnvironmentStatusLog", "dbo");

            // Set key for entity
            builder.HasKey(p => p.ID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.ID).UseSqlServerIdentityColumn();
        }
    }
}
