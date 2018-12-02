using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.WebApi.Responses;

namespace ServiceMonitor.WebApi.Controllers
{
#pragma warning disable CS1591
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        protected ILogger Logger;
        protected IDashboardService Service;

        public DashboardController(ILogger<DashboardController> logger, IDashboardService service)
        {
            Logger = logger;
            Service = service;
        }
#pragma warning restore CS1591

        // GET: api/v1/Dashboard/ServiceWatcherItem

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("ServiceWatcherItem")]
        public async Task<IActionResult> GetServiceWatcherItemsAsync()
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceWatcherItemsAsync));

            var response = await Service.GetActiveServiceWatcherItemsAsync();

            return response.ToHttpResponse();
        }

        // GET: api/v1/Dashboard/ServiceStatusDetail/{id}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ServiceStatusDetail/{id}")]
        public async Task<IActionResult> GetServiceStatusDetailsAsync(string id)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceStatusDetailsAsync));

            var response = await Service.GetServiceStatusesAsync(id);

            return response.ToHttpResponse();
        }
    }
}
