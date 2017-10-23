using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.DataLayer.Mapping;

namespace ServiceMonitor.Core.DataLayer
{
    public class ServiceMonitorDbContext : DbContext
    {
        public ServiceMonitorDbContext(DbContextOptions<ServiceMonitorDbContext> options, IEntityMapper entityMapper)
            : base(options)
        {
            EntityMapper = entityMapper;
        }

        public IEntityMapper EntityMapper { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityMapper.MapEntities(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
