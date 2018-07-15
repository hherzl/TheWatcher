using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceEnvironmentStatusMap : IEntityTypeConfiguration<ServiceEnvironmentStatus>
    {
        public void Configure(EntityTypeBuilder<ServiceEnvironmentStatus> builder)
        {
            builder.ToTable("ServiceEnvironmentStatus");

            builder.HasKey(p => p.ServiceEnvironmentStatusID);

            builder.Property(p => p.ServiceEnvironmentStatusID).UseSqlServerIdentityColumn();
        }
    }
}
