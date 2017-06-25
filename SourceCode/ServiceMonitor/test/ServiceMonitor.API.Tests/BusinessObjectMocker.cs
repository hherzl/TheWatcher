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

        public static IAdministrationBusinessObject GetAdministrationBusinessObject()
        {
            var logger = LoggerMocker.GetLogger<IAdministrationBusinessObject>();

            var appSettings = Options.Create(new AppSettings { ConnectionString = ConnectionString });

            return new AdministrationBusinessObject(logger, new ServiceMonitorDbContext(appSettings, new ServiceMonitorEntityMapper() as IEntityMapper));
        }

        public static IDashboardBusinessObject GetDashboardBusinessObject()
        {
            var logger = LoggerMocker.GetLogger<IDashboardBusinessObject>();

            var appSettings = Options.Create(new AppSettings { ConnectionString = ConnectionString });

            return new DashboardBusinessObject(logger, new ServiceMonitorDbContext(appSettings, new ServiceMonitorEntityMapper() as IEntityMapper));
        }
    }
}
