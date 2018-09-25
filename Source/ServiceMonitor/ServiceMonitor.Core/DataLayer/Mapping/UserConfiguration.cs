using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Mapping for table
            builder.ToTable("User", "dbo");

            // Set key for entity
            builder.HasKey(p => p.UserID);

            // Set identity for entity (auto increment)
            builder.Property(p => p.UserID).UseSqlServerIdentityColumn();
        }
    }
}
