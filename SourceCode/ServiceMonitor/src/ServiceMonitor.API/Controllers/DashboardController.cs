using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceMonitor.API.Responses;
using ServiceMonitor.Core.BusinessLayer.Contracts;

namespace ServiceMonitor.API.Controllers
{
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        protected ILogger Logger;
        protected IDashboardBusinessObject BusinessObject;

        public DashboardController(ILogger logger, IDashboardBusinessObject businessObject)
        {
            Logger = logger;
            BusinessObject = businessObject;
        }

        protected override void Dispose(Boolean disposing)
        {
            BusinessObject?.Dispose();

            base.Dispose(disposing);
        }

        // GET: api/Dashboard/ServiceWatcherItems

        [Route("ServiceWatcherItems")]
        public async Task<IActionResult> GetServiceWatcherItems()
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceWatcherItems));

            var response = await BusinessObject.GetActiveServiceWatcherItemsAsync();

            return response.ToHttpResponse();
        }

        // GET: api/Dashboard/ServiceStatusDetails/{userName}

        [Route("ServiceStatusDetails/{userName}")]
        public async Task<IActionResult> GetServiceStatusDetails(String userName)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceStatusDetails));

            var response = await BusinessObject.GetServiceStatusesAsync(userName);

            return response.ToHttpResponse();
        }
    }
}
