using Microsoft.EntityFrameworkCore;
using TheWatcher.Domain.Core.Models;
using TheWatcher.Domain.Core.Configurations;

namespace TheWatcher.Domain.Core
{
	public class TheWatcherDbContext : DbContext
	{
		public TheWatcherDbContext(DbContextOptions<TheWatcherDbContext> options)
			: base(options)
		{
		}

		public DbSet<ResourceCategory> ResourceCategory { get; set; }

		public DbSet<Models.Environment> Environment { get; set; }

		public DbSet<Resource> Resource { get; set; }

		public DbSet<ResourceWatch> ResourceWatch { get; set; }

		public DbSet<ResourceWatcherParameter> ResourceWatcherParameter { get; set; }

		public DbSet<Watcher> Watcher { get; set; }

		public DbSet<ResourceWatcher> ResourceWatcher { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Apply all configurations for tables

			// Schema 'dbo'
			modelBuilder
				.ApplyConfiguration(new ResourceCategoryConfiguration())
				.ApplyConfiguration(new EnvironmentConfiguration())
				.ApplyConfiguration(new ResourceConfiguration())
				.ApplyConfiguration(new ResourceWatchConfiguration())
				.ApplyConfiguration(new ResourceWatcherParameterConfiguration())
				.ApplyConfiguration(new WatcherConfiguration())
				.ApplyConfiguration(new ResourceWatcherConfiguration())
			;

			base.OnModelCreating(modelBuilder);
		}
	}
}
