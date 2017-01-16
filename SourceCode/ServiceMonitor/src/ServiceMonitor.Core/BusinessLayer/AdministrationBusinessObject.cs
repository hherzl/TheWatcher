using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Core.DataLayer;
using ServiceMonitor.Core.DataLayer.Contracts;

namespace ServiceMonitor.Core.BusinessLayer
{
    public partial class AdministrationBusinessObject : IAdministrationBusinessObject
    {
        private readonly IAdministrationUow AdministrationUow;

        public AdministrationBusinessObject(ServiceMonitorDbContext dbContext)
        {
            AdministrationUow = new AdministrationUow(dbContext);
        }

        public void Release()
        {
            if (AdministrationUow != null)
            {
                AdministrationUow.Dispose();
            }
        }
    }
}
