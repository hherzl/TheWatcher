using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServiceMonitor.Core.DataLayer.Mapping;

namespace ServiceMonitor.Core.DataLayer
{
    public class ServiceMonitorDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ServiceMonitorDbContext(IOptions<AppSettings> appSettings, IEntityMapper entityMapper)
        {
            ConnectionString = appSettings.Value.ConnectionString;
            EntityMapper = entityMapper;
        }

        public String ConnectionString { get; }

        public IEntityMapper EntityMapper { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityMapper.MapEntities(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
