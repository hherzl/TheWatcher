using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceCategoryMap : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.ToTable("ServiceCategory");

            builder.HasKey(p => p.ServiceCategoryID);

            builder.Property(p => p.ServiceCategoryID).UseSqlServerIdentityColumn();
        }
    }
}
