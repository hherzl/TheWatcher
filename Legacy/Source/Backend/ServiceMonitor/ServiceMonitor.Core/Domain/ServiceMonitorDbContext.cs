using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.Domain.Configurations;

namespace ServiceMonitor.Core.Domain
{
    public class ServiceMonitorDbContext : DbContext
    {
        public ServiceMonitorDbContext(DbContextOptions<ServiceMonitorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Environment> Environments { get; set; }

        public DbSet<ServiceCategory> ServiceCategories { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Watcher> Watchers { get; set; }

        public DbSet<ServiceWatcher> ServiceWatchers { get; set; }

        public DbSet<ServiceUser> ServiceUsers { get; set; }

        public DbSet<ServiceEnvironment> ServiceEnvironments { get; set; }

        public DbSet<ServiceEnvironmentStatusLog> ServiceEnvironmentStatusLogs { get; set; }

        public DbSet<ServiceEnvironmentStatus> ServiceEnvironmentStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new EnvironmentConfiguration())
                .ApplyConfiguration(new ServiceCategoryConfiguration())
                .ApplyConfiguration(new ServiceConfiguration())
                .ApplyConfiguration(new WatcherConfiguration())
                .ApplyConfiguration(new ServiceWatcherConfiguration())
                .ApplyConfiguration(new ServiceUserConfiguration())
                .ApplyConfiguration(new ServiceEnvironmentConfiguration())
                .ApplyConfiguration(new ServiceEnvironmentStatusLogConfiguration())
                .ApplyConfiguration(new ServiceEnvironmentStatusConfiguration())
                ;

            base.OnModelCreating(modelBuilder);
        }
    }
}
