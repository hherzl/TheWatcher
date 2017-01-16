using Microsoft.Extensions.Options;
using ServiceMonitor.Core.BusinessLayer;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Core.DataLayer;
using ServiceMonitor.Core.DataLayer.Mapping;

namespace ServiceMonitor.Mocks
{
    public static class BusinessObjectMocker
    {
        public static IAdministrationBusinessObject GetAdministrationBusinessObject()
        {
            var appSettings = Options.Create(new AppSettings { ConnectionString = "server=(local);database=ServiceMonitor;integrated security=yes;" });

            var entityMapper = new ServiceMonitorEntityMapper() as IEntityMapper;

            return new AdministrationBusinessObject(new ServiceMonitorDbContext(appSettings, entityMapper)) as IAdministrationBusinessObject;
        }
    }
}
