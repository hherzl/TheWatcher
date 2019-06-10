using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServiceMonitor.Core.DomainDrivenDesign.Configurations
{
    public class ServiceOwnerConfiguration : IEntityTypeConfiguration<ServiceOwner>
    {
        public void Configure(EntityTypeBuilder<ServiceOwner> builder)
        {
            // Mapping for table
            builder.ToTable("ServiceOwner", "dbo");

            // Set key for entity
            builder.HasKey(p => p.ID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.ID).UseSqlServerIdentityColumn();
        }
    }
}
