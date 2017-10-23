using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Core.BusinessLayer;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Core.DataLayer;
using ServiceMonitor.Core.DataLayer.Mapping;

namespace ServiceMonitor.API.Tests
{
    public static class ServiceMocker
    {
        public static IAdministrationService GetAdministrationBusinessObject()
        {
            var logger = LoggerMocker.GetLogger<IAdministrationService>();

            var options = new DbContextOptionsBuilder<ServiceMonitorDbContext>()
                .UseSqlServer("server=(local);database=ServiceMonitor;integrated security=yes;MultipleActiveResultSets=True;")
                .Options;

            return new AdministrationService(logger, new ServiceMonitorDbContext(options, new ServiceMonitorEntityMapper()));
        }

        public static IDashboardService GetDashboardBusinessObject()
        {
            var logger = LoggerMocker.GetLogger<IDashboardService>();

            var options = new DbContextOptionsBuilder<ServiceMonitorDbContext>()
                .UseSqlServer("server=(local);database=ServiceMonitor;integrated security=yes;MultipleActiveResultSets=True;")
                .Options;

            return new DashboardService(logger, new ServiceMonitorDbContext(options, new ServiceMonitorEntityMapper()));
        }
    }
}
