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
                .ApplyConfiguration(new OwnerMap())
                .ApplyConfiguration(new ServiceCategoryMap())
                .ApplyConfiguration(new ServiceMap())
                .ApplyConfiguration(new ServiceEnvironmentMap())
                .ApplyConfiguration(new ServiceOwnerMap())
                .ApplyConfiguration(new ServiceEnvironmentStatusLogMap())
                .ApplyConfiguration(new ServiceEnvironmentStatusMap())
                .ApplyConfiguration(new ServiceUserMap())
                .ApplyConfiguration(new ServiceWatcherMap())
                .ApplyConfiguration(new UserMap())
                .ApplyConfiguration(new EnvironmentCategoryMap())
                ;

            base.OnModelCreating(modelBuilder);
        }
    }
}
