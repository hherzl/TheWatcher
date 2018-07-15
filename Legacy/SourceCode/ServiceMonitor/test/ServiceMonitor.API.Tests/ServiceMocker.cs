using Microsoft.EntityFrameworkCore;
using ServiceMonitor.Common;
using ServiceMonitor.Core.BusinessLayer;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Core.DataLayer;

namespace ServiceMonitor.API.Tests
{
    public static class ServiceMocker
    {
        public static IAdministrationService GetAdministrationService()
        {
            var options = new DbContextOptionsBuilder<ServiceMonitorDbContext>()
                .UseSqlServer("server=(local);database=ServiceMonitor;integrated security=yes;MultipleActiveResultSets=True;")
                .Options;

            return new AdministrationService(LoggerHelper.GetLogger<IAdministrationService>(), new ServiceMonitorDbContext(options));
        }

        public static IDashboardService GetDashboardService()
        {
            var options = new DbContextOptionsBuilder<ServiceMonitorDbContext>()
                .UseSqlServer("server=(local);database=ServiceMonitor;integrated security=yes;MultipleActiveResultSets=True;")
                .Options;

            return new DashboardService(LoggerHelper.GetLogger<IDashboardService>(), new ServiceMonitorDbContext(options));
        }
    }
}
