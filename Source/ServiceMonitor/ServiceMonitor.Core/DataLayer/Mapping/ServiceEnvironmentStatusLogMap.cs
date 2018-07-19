using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class ServiceEnvironmentStatusLogMap : IEntityTypeConfiguration<ServiceEnvironmentStatusLog>
    {
        public void Configure(EntityTypeBuilder<ServiceEnvironmentStatusLog> builder)
        {
            builder.ToTable("ServiceEnvironmentStatusLog");

            builder.HasKey(p => p.ServiceEnvironmentStatusLogID);

            builder.Property(p => p.ServiceEnvironmentStatusLogID).UseSqlServerIdentityColumn();
        }
    }
}
