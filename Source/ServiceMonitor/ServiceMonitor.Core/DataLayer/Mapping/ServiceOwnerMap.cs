using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceOwnerMap : IEntityTypeConfiguration<ServiceOwner>
    {
        public void Configure(EntityTypeBuilder<ServiceOwner> builder)
        {
            builder.ToTable("ServiceOwner");

            builder.HasKey(p => p.ServiceOwnerID);

            builder.Property(p => p.ServiceOwnerID).UseSqlServerIdentityColumn();
        }
    }
}
