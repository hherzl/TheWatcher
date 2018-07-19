using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceEnvironmentMap : IEntityTypeConfiguration<ServiceEnvironment>
    {
        public void Configure(EntityTypeBuilder<ServiceEnvironment> builder)
        {
            builder.ToTable("ServiceEnvironment");

            builder.HasKey(p => p.ServiceEnvironmentID);

            builder.Property(p => p.ServiceEnvironmentID).UseSqlServerIdentityColumn();
        }
    }
}
