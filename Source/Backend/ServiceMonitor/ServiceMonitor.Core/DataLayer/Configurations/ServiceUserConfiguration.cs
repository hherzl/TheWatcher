using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Configurations
{
    public class ServiceUserConfiguration : IEntityTypeConfiguration<ServiceUser>
    {
        public void Configure(EntityTypeBuilder<ServiceUser> builder)
        {
            // Mapping for table
            builder.ToTable("ServiceUser", "dbo");

            // Set key for entity
            builder.HasKey(p => p.ServiceUserID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.ServiceUserID).UseSqlServerIdentityColumn();
        }
    }
}
