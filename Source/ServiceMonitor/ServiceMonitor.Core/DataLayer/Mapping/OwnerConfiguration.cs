using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            // Mapping for table
            builder.ToTable("Owner");

            // Set key for entity
            builder.HasKey(p => p.OwnerID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.OwnerID).UseSqlServerIdentityColumn();
        }
    }
}
