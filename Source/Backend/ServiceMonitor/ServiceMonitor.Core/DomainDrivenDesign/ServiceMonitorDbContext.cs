using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.DomainDrivenDesign.Configurations;
using ServiceMonitor.Core.DomainDrivenDesign;

namespace ServiceMonitor.Core.DomainDrivenDesign
{
    public class ServiceMonitorDbContext : DbContext
    {
        public ServiceMonitorDbContext(DbContextOptions<ServiceMonitorDbContext> options)
            : base(options)
        {
        }

        public DbSet<EnvironmentCategory> EnvironmentCategory { get; set; }

        public DbSet<Owner> Owner { get; set; }

        public DbSet<ServiceCategory> ServiceCategory { get; set; }

        public DbSet<Service> Service { get; set; }

        public DbSet<ServiceEnvironment> ServiceEnvironment { get; set; }

        public DbSet<ServiceEnvironmentStatusLog> ServiceEnvironmentStatusLog { get; set; }

        public DbSet<ServiceEnvironmentStatus> ServiceEnvironmentStatus { get; set; }

        public DbSet<ServiceOwner> ServiceOwner { get; set; }

        public DbSet<ServiceUser> ServiceUser { get; set; }

        public DbSet<ServiceWatcher> ServiceWatcher { get; set; }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new EnvironmentCategoryConfiguration())
                .ApplyConfiguration(new OwnerConfiguration())
                .ApplyConfiguration(new ServiceCategoryConfiguration())
                .ApplyConfiguration(new ServiceConfiguration())
                .ApplyConfiguration(new ServiceEnvironmentConfiguration())
                .ApplyConfiguration(new ServiceEnvironmentStatusLogConfiguration())
                .ApplyConfiguration(new ServiceEnvironmentStatusConfiguration())
                .ApplyConfiguration(new ServiceOwnerConfiguration())
                .ApplyConfiguration(new ServiceUserConfiguration())
                .ApplyConfiguration(new ServiceWatcherConfiguration())
                .ApplyConfiguration(new UserConfiguration())
                ;

            base.OnModelCreating(modelBuilder);
        }
    }
}
