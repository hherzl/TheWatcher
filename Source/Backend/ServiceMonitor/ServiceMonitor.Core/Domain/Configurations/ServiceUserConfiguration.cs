using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServiceMonitor.Core.Domain.Configurations
{
    public class ServiceUserConfiguration : IEntityTypeConfiguration<ServiceUser>
    {
        public void Configure(EntityTypeBuilder<ServiceUser> builder)
        {
            // Mapping for table
            builder.ToTable("ServiceUser", "dbo");

            // Set key for entity
            builder.HasKey(p => p.ID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.ID).UseSqlServerIdentityColumn();
        }
    }
}
