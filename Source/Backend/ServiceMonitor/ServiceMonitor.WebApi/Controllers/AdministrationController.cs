using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.WebApi.Requests;
using ServiceMonitor.WebApi.Responses;

namespace ServiceMonitor.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        protected ILogger Logger;
        protected IAdministrationService Service;

        public AdministrationController(ILogger<AdministrationController> logger, IAdministrationService service)
        {
            Logger = logger;
            Service = service;
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
