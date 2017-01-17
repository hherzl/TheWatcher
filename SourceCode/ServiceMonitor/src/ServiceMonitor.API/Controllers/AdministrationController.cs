using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceMonitor.API.Extensions;
using ServiceMonitor.API.Responses;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Responses;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Controllers
{
    [Route("api/[controller]")]
    public class AdministrationController : Controller
    {
        protected IAdministrationBusinessObject BusinessObject;

        public AdministrationController(IAdministrationBusinessObject businessObject)
        {
            BusinessObject = businessObject;
        }

        protected override void Dispose(Boolean disposing)
        {
            BusinessObject?.Dispose();

            base.Dispose(disposing);
        }

        [Route("ServiceStatusLog")]
        [HttpPost]
        public async Task<IActionResult> CreateServiceStatusLog([FromBody]ServiceStatusLogViewModel value)
        {
            var response = new SingleViewModelResponse<ServiceStatusLogViewModel>() as ISingleViewModelResponse<ServiceStatusLogViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return BusinessObject.CreateServiceStatusLog(value.ToEntity());
                });

                response.Model = entity.ToViewModel();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }
    }
}
