using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheWatcher.Domain.Core.Configurations
{
	internal class EnvironmentConfiguration : IEntityTypeConfiguration<Models.Environment>
	{
		public void Configure(EntityTypeBuilder<Models.Environment> builder)
		{
			// Set configuration for entity
			builder.ToTable("Environment", "dbo");

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
		}
	}
}
