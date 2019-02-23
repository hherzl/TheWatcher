using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.DomainDrivenDesign.Configurations;

namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public class ServiceMonitorDbContext : DbContext
    {
        public ServiceMonitorDbContext(DbContextOptions<ServiceMonitorDbContext> options)
            : base(options)
        {
        }

        public DbSet<EnvironmentCategory> EnvironmentCategories { get; set; }

        public DbSet<ServiceCategory> ServiceCategories { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<ServiceWatcher> ServiceWatchers { get; set; }

        public DbSet<ServiceEnvironment> ServiceEnvironments { get; set; }

        public DbSet<ServiceEnvironmentStatusLog> ServiceEnvironmentStatusLogs { get; set; }

        public DbSet<ServiceEnvironmentStatus> ServiceEnvironmentStatuses { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<ServiceOwner> ServiceOwners { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ServiceUser> ServiceUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new EnvironmentCategoryConfiguration())
                .ApplyConfiguration(new ServiceCategoryConfiguration())
                .ApplyConfiguration(new ServiceConfiguration())
                .ApplyConfiguration(new ServiceWatcherConfiguration())
                .ApplyConfiguration(new ServiceEnvironmentConfiguration())
                .ApplyConfiguration(new ServiceEnvironmentStatusLogConfiguration())
                .ApplyConfiguration(new ServiceEnvironmentStatusConfiguration())
                ;

            modelBuilder
                .ApplyConfiguration(new OwnerConfiguration())
                .ApplyConfiguration(new ServiceOwnerConfiguration())
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new ServiceUserConfiguration())
                ;

            base.OnModelCreating(modelBuilder);
        }
    }
}
