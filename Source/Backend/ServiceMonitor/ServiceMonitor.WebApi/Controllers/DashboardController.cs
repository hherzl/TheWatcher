using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.WebAPI.Responses;

namespace ServiceMonitor.WebAPI.Controllers
{
#pragma warning disable CS1591
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly IDashboardService Service;

        public DashboardController(ILogger<DashboardController> logger, IDashboardService service)
        {
            Logger = logger;
            Service = service;
        }
#pragma warning restore CS1591

        /// <summary>
        /// Gets service watcher items (registered services to watch with service monitor)
        /// </summary>
        /// <returns>A sequence of services to watch</returns>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet("ServiceWatcherItem")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetServiceWatcherItemsAsync()
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceWatcherItemsAsync));

            var response = await Service.GetActiveServiceWatcherItemsAsync();

            return response.ToHttpResponse();
        }

        /// <summary>
        /// Gets the details for service watch
        /// </summary>
        /// <param name="id">Service ID</param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        /// <response code="500"></response>
        [HttpGet("ServiceStatusDetail/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetServiceStatusDetailsAsync(string id)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetServiceStatusDetailsAsync));

            var response = await Service.GetServiceStatusesAsync(id);

            return response.ToHttpResponse();
        }
    }
}
