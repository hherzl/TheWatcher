using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceUserMap : IEntityTypeConfiguration<ServiceUser>
    {
        public void Configure(EntityTypeBuilder<ServiceUser> builder)
        {
            builder.ToTable("ServiceUser");

            builder.HasKey(p => p.ServiceUserID);

            builder.Property(p => p.ServiceUserID).UseSqlServerIdentityColumn();
        }
    }
}
