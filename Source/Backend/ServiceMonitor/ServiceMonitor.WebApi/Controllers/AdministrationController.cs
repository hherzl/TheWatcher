using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Core.Business.Contracts;
using ServiceMonitor.WebAPI.Requests;
using ServiceMonitor.WebAPI.Responses;

namespace ServiceMonitor.WebAPI.Controllers
{
#pragma warning disable CS1591
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        readonly ILogger Logger;
        readonly IAdministrationService Service;

        public AdministrationController(ILogger<AdministrationController> logger, IAdministrationService service)
        {
            Logger = logger;
            Service = service;
        }
#pragma warning restore CS1591

        /// <summary>
        /// Saves a result from service watch action
        /// </summary>
        /// <param name="request">Service status result</param>
        /// <returns>Ok if save it was successfully, Not found if service not exists else server internal error</returns>
        /// <response code="201">If service log was created succesfully</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpPost("ServiceEnvironmentStatusLog")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostServiceEnvironmentStatusLogAsync([FromBody]PostServiceEnvironmentStatusLogRequest request)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(PostServiceEnvironmentStatusLogAsync));

            var response = await Service
                .CreateServiceEnvironmentStatusLogAsync(request.ToEntity(), request.ServiceEnvironmentID);

            return response.ToHttpCreatedResponse();
        }
    }
}
