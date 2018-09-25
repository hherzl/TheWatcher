using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceEnvironmentStatusLogConfiguration : IEntityTypeConfiguration<ServiceEnvironmentStatusLog>
    {
        public void Configure(EntityTypeBuilder<ServiceEnvironmentStatusLog> builder)
        {
            // Mapping for table
            builder.ToTable("ServiceEnvironmentStatusLog", "dbo");

            // Set key for entity
            builder.HasKey(p => p.ServiceEnvironmentStatusLogID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.ServiceEnvironmentStatusLogID).UseSqlServerIdentityColumn();
        }
    }
}
