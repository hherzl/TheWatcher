using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Domain.Core.Configurations
{
	internal class ResourceWatcherParameterConfiguration : IEntityTypeConfiguration<ResourceWatcherParameter>
	{
		public void Configure(EntityTypeBuilder<ResourceWatcherParameter> builder)
		{
			// Set configuration for entity
			builder.ToTable("ResourceWatcherParameter", "dbo");

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
				.Property(p => p.ResourceId)
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
				.Property(p => p.Description)
				.HasColumnType("nvarchar(max)")
				.IsRequired()
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

			// Add configuration for uniques

			builder
				.HasIndex(p => new { p.ResourceId, p.Parameter })
				.IsUnique()
				.HasDatabaseName("UQ_dbo_ResourceWatcherParameter_ResourceId_Parameter")
				;

			// Add configuration for foreign keys

			builder
				.HasOne(p => p.ResourceFk)
				.WithMany(b => b.ResourceWatcherParameterList)
				.HasForeignKey(p => p.ResourceId)
				.HasConstraintName("FK_dbo_ResourceWatcherParameter_ResourceId_dbo_Resource")
				;
		}
	}
}
