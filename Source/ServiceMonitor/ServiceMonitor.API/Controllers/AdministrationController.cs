using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceMonitor.API.Responses;
using ServiceMonitor.API.ViewModels;
using ServiceMonitor.Core.BusinessLayer.Contracts;

namespace ServiceMonitor.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class AdministrationController : Controller
    {
        protected ILogger Logger;
        protected IAdministrationService Service;

        public AdministrationController(ILogger<AdministrationController> logger, IAdministrationService service)
        {
            Logger = logger;
            Service = service;
        }

        protected override void Dispose(bool disposing)
        {
            Service?.Dispose();

            base.Dispose(disposing);
        }

        // POST: api/v1/Dashboard/ServiceWatcherItems

        [HttpPost("ServiceStatusLog")]
        public async Task<IActionResult> CreateServiceStatusLogAsync([FromBody]ServiceEnvironmentStatusLogVm value)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(CreateServiceStatusLogAsync));

            var response = await Service
                .CreateServiceEnvironmentStatusLogAsync(value.ToEntity(), value.ServiceEnvironmentID);

            return response.ToHttpResponse();
        }
    }
}
