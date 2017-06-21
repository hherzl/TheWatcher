using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceMonitor.API.Extensions;
using ServiceMonitor.API.Responses;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Controllers
{
    [Route("api/[controller]")]
    public class AdministrationController : Controller
    {
        protected ILogger Logger;
        protected IAdministrationBusinessObject BusinessObject;

        public AdministrationController(ILogger logger, IAdministrationBusinessObject businessObject)
        {
            Logger = logger;
            BusinessObject = businessObject;
        }

        protected override void Dispose(Boolean disposing)
        {
            BusinessObject?.Dispose();

            base.Dispose(disposing);
        }

        [HttpPost]
        [Route("ServiceStatusLog")]
        public async Task<IActionResult> CreateServiceStatusLog([FromBody]ServiceEnvironmentStatusLogVm value)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(CreateServiceStatusLog));

            var response = await BusinessObject.CreateServiceEnvironmentStatusLogAsync(value.ToEntity(), value.ServiceEnvironmentID);

            return response.ToHttpResponse();
        }
    }
}
