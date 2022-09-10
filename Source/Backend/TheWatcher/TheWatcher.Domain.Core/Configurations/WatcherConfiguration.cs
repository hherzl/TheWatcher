using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Domain.Core.Configurations
{
	internal class WatcherConfiguration : IEntityTypeConfiguration<Watcher>
	{
		public void Configure(EntityTypeBuilder<Watcher> builder)
		{
			// Set configuration for entity
			builder.ToTable("Watcher", "dbo");

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
				.Property(p => p.AssemblyQualifiedName)
				.HasColumnType("nvarchar")
				.HasMaxLength(511)
				.IsRequired()
				;

			builder
				.Property(p => p.Name)
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
				.HasIndex(p => p.AssemblyQualifiedName)
				.IsUnique()
				.HasDatabaseName("UQ_dbo_Watcher_AssemblyQualifiedName")
				;

			builder
				.HasIndex(p => p.Name)
				.IsUnique()
				.HasDatabaseName("UQ_dbo_Watcher_Name")
				;
		}
	}
}
