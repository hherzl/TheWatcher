using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMonitor.Core.EntityLayer;

namespace ServiceMonitor.Core.DataLayer.Mapping
{
    public class EnvironmentCategoryMap : IEntityTypeConfiguration<EnvironmentCategory>
    {
        public void Configure(EntityTypeBuilder<EnvironmentCategory> builder)
        {
            builder.ToTable("EnvironmentCategory");

            builder.HasKey(p => p.EnvironmentCategoryID);

            builder.Property(p => p.EnvironmentCategoryID).UseSqlServerIdentityColumn();
        }
    }
}
