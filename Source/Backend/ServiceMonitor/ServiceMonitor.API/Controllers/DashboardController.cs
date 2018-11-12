using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceMonitor.API.Responses;
using ServiceMonitor.Core.BusinessLayer.Contracts;

namespace ServiceMonitor.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class DashboardController : Controller
    {
        protected ILogger Logger;
        protected IDashboardService Service;

        public DashboardController(ILogger<DashboardController> logger, IDashboardService service)
        {
            Logger = logger;
            Service = service;
        }

        protected override void Dispose(bool disposing)
        {
            Service?.Dispose();

            base.Dispose(disposing);
        }

        // GET: api/v1/Dashboard/ServiceWatcherItem

        [HttpGet("ServiceWatcherItem")]
        public async Task<IActionResult> GetServiceWatcherItemsAsync()
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceWatcherItemsAsync));

            var response = await Service.GetActiveServiceWatcherItemsAsync();

            return response.ToHttpResponse();
        }

        // GET: api/v1/Dashboard/ServiceStatusDetail/{id}

        [HttpGet("ServiceStatusDetail/{id}")]
        public async Task<IActionResult> GetServiceStatusDetailsAsync(string id)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceStatusDetailsAsync));

            var response = await Service.GetServiceStatusesAsync(id);

            return response.ToHttpResponse();
        }
    }
}
