using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Domain.Core.Configurations
{
	internal class ResourceWatchConfiguration : IEntityTypeConfiguration<ResourceWatch>
	{
		public void Configure(EntityTypeBuilder<ResourceWatch> builder)
		{
			// Set configuration for entity
			builder.ToTable("ResourceWatch", "dbo");

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
				.Property(p => p.EnvironmentId)
				.HasColumnType("smallint")
				.IsRequired()
				;

			builder
				.Property(p => p.Interval)
				.HasColumnType("int")
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
				.HasIndex(p => new { p.ResourceId, p.EnvironmentId })
				.IsUnique()
				.HasDatabaseName("UQ_dbo_ResourceWatch_ResourceId_EnvironmentId")
				;

			// Add configuration for foreign keys

			builder
				.HasOne(p => p.ResourceFk)
				.WithMany(b => b.ResourceWatchList)
				.HasForeignKey(p => p.ResourceId)
				.HasConstraintName("FK_dbo_ResourceWatch_ResourceId_dbo_Resource")
				;

			builder
				.HasOne(p => p.EnvironmentFk)
				.WithMany(b => b.ResourceWatchList)
				.HasForeignKey(p => p.EnvironmentId)
				.HasConstraintName("FK_dbo_ResourceWatch_EnvironmentId_dbo_Environment")
				;
		}
	}
}
