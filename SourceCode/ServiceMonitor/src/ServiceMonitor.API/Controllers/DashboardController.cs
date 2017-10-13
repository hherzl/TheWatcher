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
        protected IDashboardService Service;

        public DashboardController(ILogger logger, IDashboardService service)
        {
            Logger = logger;
            Service = service;
        }

        protected override void Dispose(Boolean disposing)
        {
            Service?.Dispose();

            base.Dispose(disposing);
        }

        // GET: api/Dashboard/ServiceWatcherItems

        [Route("ServiceWatcherItems")]
        public async Task<IActionResult> GetServiceWatcherItemsAsync()
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceWatcherItemsAsync));

            var response = await Service.GetActiveServiceWatcherItemsAsync();

            return response.ToHttpResponse();
        }

        // GET: api/Dashboard/ServiceStatusDetails/{userName}

        [Route("ServiceStatusDetails/{userName}")]
        public async Task<IActionResult> GetServiceStatusDetailsAsync(String userName)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceStatusDetailsAsync));

            var response = await Service.GetServiceStatusesAsync(userName);

            return response.ToHttpResponse();
        }
    }
}
