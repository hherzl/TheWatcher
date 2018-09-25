using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class EnvironmentCategoryConfiguration : IEntityTypeConfiguration<EnvironmentCategory>
    {
        public void Configure(EntityTypeBuilder<EnvironmentCategory> builder)
        {
            // Mapping for table
            builder.ToTable("EnvironmentCategory", "dbo");

            // Set key for entity
            builder.HasKey(p => p.EnvironmentCategoryID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.EnvironmentCategoryID).UseSqlServerIdentityColumn();
        }
    }
}
