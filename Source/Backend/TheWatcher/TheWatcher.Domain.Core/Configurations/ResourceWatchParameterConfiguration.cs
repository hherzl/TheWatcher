using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Domain.Core.Configurations
{
	internal class ResourceWatchParameterConfiguration : IEntityTypeConfiguration<ResourceWatchParameter>
	{
		public void Configure(EntityTypeBuilder<ResourceWatchParameter> builder)
		{
			// Set configuration for entity
			builder.ToTable("ResourceWatchParameter", "dbo");

			// Set key for entity
			builder.HasKey(p => p.Id);

			// Set identity for entity (auto increment)
			builder.Property(p => p.Id).UseIdentityColumn();

			// Set configuration for columns
			builder
				.Property(p => p.Id)
				.HasColumnType("smallint")
				.IsRequired()
				;

			builder
				.Property(p => p.ResourceWatchId)
				.HasColumnType("smallint")
				.IsRequired()
				;

			builder
				.Property(p => p.Parameter)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired()
				;

			builder
				.Property(p => p.Value)
				.HasColumnType("nvarchar(max)")
				;

			builder
				.Property(p => p.Description)
				.HasColumnType("nvarchar(max)")
				;

			builder
				.Property(p => p.Active)
				.HasColumnType("bit")
				.IsRequired()
				;

			builder
				.Property(p => p.CreationUser)
				.HasColumnType("nvarchar")
				.HasMaxLength(50)
				.IsRequired()
				;

			builder
				.Property(p => p.CreationDateTime)
				.HasColumnType("datetime")
				.IsRequired()
				;

			builder
				.Property(p => p.LastUpdateUser)
				.HasColumnType("nvarchar")
				.HasMaxLength(50)
				;

			builder
				.Property(p => p.LastUpdateDateTime)
				.HasColumnType("datetime")
				;

			builder
				.Property(p => p.Version)
				.HasColumnType("rowversion")
				;

            // Add configuration for row version

            builder
                .Property(p => p.Version)
                .ValueGeneratedOnAddOrUpdate()
                .IsRowVersion()
                ;

            // Add configuration for uniques

            builder
				.HasIndex(p => new { p.ResourceWatchId, p.Parameter })
				.IsUnique()
				.HasDatabaseName("UQ_dbo_ResourceWatchParameter_ResourceWatchId_Parameter");

			// Add configuration for foreign keys

			builder
				.HasOne(p => p.ResourceWatchFk)
				.WithMany(b => b.ResourceWatchParameterList)
				.HasForeignKey(p => p.ResourceWatchId)
				.HasConstraintName("FK_dbo_ResourceWatchParameter_ResourceWatchId_dbo_ResourceWatch");
		}
	}
}
