using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServiceMonitor.Core.Domain.Configurations
{
    public class ServiceEnvironmentConfiguration : IEntityTypeConfiguration<ServiceEnvironment>
    {
        public void Configure(EntityTypeBuilder<ServiceEnvironment> builder)
        {
            // Mapping for table
            builder.ToTable("ServiceEnvironment", "dbo");

            // Set key for entity
            builder.HasKey(p => p.ID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.ID).UseSqlServerIdentityColumn();
        }
    }
}
