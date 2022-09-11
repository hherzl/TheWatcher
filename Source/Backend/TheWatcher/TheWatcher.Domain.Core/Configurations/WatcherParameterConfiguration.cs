using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Domain.Core.Configurations
{
	internal class WatcherParameterConfiguration : IEntityTypeConfiguration<WatcherParameter>
	{
		public void Configure(EntityTypeBuilder<WatcherParameter> builder)
		{
			// Set configuration for entity
			builder.ToTable("WatcherParameter", "dbo");

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
				.Property(p => p.WatcherId)
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
				.Property(p => p.IsDefault)
				.HasColumnType("bit")
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
				.HasIndex(p => new { p.WatcherId, p.Parameter })
				.IsUnique()
				.HasDatabaseName("UQ_dbo_WatcherParameter_WatcherId_Parameter");

			// Add configuration for foreign keys

			builder
				.HasOne(p => p.WatcherFk)
				.WithMany(b => b.WatcherParameterList)
				.HasForeignKey(p => p.WatcherId)
				.HasConstraintName("FK_dbo_WatcherParameter_WatcherId_dbo_Watcher");
		}
	}
}
