using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            // Mapping for table
            builder.ToTable("ServiceCategory", "dbo");

            // Set key for entity
            builder.HasKey(p => p.ServiceCategoryID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.ServiceCategoryID).UseSqlServerIdentityColumn();
        }
    }
}
