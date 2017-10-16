using System;
using Microsoft.Extensions.Options;
using ServiceMonitor.Core.BusinessLayer;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Core.DataLayer;
using ServiceMonitor.Core.DataLayer.Mapping;

namespace ServiceMonitor.API.Tests
{
    public static class BusinessObjectMocker
    {
        private static String ConnectionString
            => "server=(local);database=ServiceMonitor;integrated security=yes;MultipleActiveResultSets=True;";

        public static IAdministrationService GetAdministrationBusinessObject()
        {
            var logger = LoggerMocker.GetLogger<IAdministrationService>();

            var appSettings = Options.Create(new AppSettings { ConnectionString = ConnectionString });

            return new AdministrationService(logger, new ServiceMonitorDbContext(appSettings, new ServiceMonitorEntityMapper()));
        }

        public static IDashboardService GetDashboardBusinessObject()
        {
            var logger = LoggerMocker.GetLogger<IDashboardService>();

            var appSettings = Options.Create(new AppSettings { ConnectionString = ConnectionString });

            return new DashboardService(logger, new ServiceMonitorDbContext(appSettings, new ServiceMonitorEntityMapper()));
        }
    }
}
