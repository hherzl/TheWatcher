using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.DataLayer.Mapping;

namespace ServiceMonitor.Core.DataLayer
{
    public class ServiceMonitorDbContext : DbContext
    {
        public ServiceMonitorDbContext(DbContextOptions<ServiceMonitorDbContext> options)
            : base(options)
        {
        }

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
