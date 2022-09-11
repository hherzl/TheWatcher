using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Domain.Core.Configurations
{
	internal class ResourceCategoryConfiguration : IEntityTypeConfiguration<ResourceCategory>
	{
		public void Configure(EntityTypeBuilder<ResourceCategory> builder)
		{
			// Set configuration for entity
			builder.ToTable("ResourceCategory", "dbo");

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
				.Property(p => p.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired()
				;

			builder
				.Property(p => p.WatcherId)
				.HasColumnType("smallint")
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
				.HasIndex(p => p.Name)
				.IsUnique()
				.HasDatabaseName("UQ_dbo_ResourceCategory_Name");

			// Add configuration for foreign keys

			builder
				.HasOne(p => p.WatcherFk)
				.WithMany(b => b.ResourceCategoryList)
				.HasForeignKey(p => p.WatcherId)
				.HasConstraintName("FK_dbo_ResourceCategory_WatcherId_dbo_Watcher");
		}
	}
}
