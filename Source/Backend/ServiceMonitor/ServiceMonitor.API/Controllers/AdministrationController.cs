using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceMonitor.API.Requests;
using ServiceMonitor.API.Responses;
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

        // POST: api/v1/Dashboard/ServiceStatusLog

        [HttpPost("ServiceEnvironmentStatusLog")]
        public async Task<IActionResult> PostServiceStatusLogAsync([FromBody]ServiceEnvironmentStatusLogRequest value)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(PostServiceStatusLogAsync));

            var response = await Service
                .CreateServiceEnvironmentStatusLogAsync(value.ToEntity(), value.ServiceEnvironmentID);

            return response.ToHttpResponse();
        }
    }
}
