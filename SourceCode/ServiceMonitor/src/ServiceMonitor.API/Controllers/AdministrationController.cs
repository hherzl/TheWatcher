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
        protected IAdministrationService Service;

        public AdministrationController(ILogger logger, IAdministrationService service)
        {
            Logger = logger;
            Service = service;
        }

        protected override void Dispose(Boolean disposing)
        {
            Service?.Dispose();

            base.Dispose(disposing);
        }

        [HttpPost]
        [Route("ServiceStatusLog")]
        public async Task<IActionResult> CreateServiceStatusLogAsync([FromBody]ServiceEnvironmentStatusLogVm value)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(CreateServiceStatusLogAsync));

            var response = await Service.CreateServiceEnvironmentStatusLogAsync(value.ToEntity(), value.ServiceEnvironmentID);

            return response.ToHttpResponse();
        }
    }
}
