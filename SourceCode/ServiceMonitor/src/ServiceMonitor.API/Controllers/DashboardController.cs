using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceMonitor.API.Extensions;
using ServiceMonitor.API.Responses;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Core.EntityLayer;
using ServiceMonitor.Responses;
using ServiceMonitor.ViewModels;

namespace ServiceMonitor.API.Controllers
{
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        protected IDashboardBusinessObject BusinessObject;

        public DashboardController(IDashboardBusinessObject businessObject)
        {
            BusinessObject = businessObject;
        }

        protected override void Dispose(Boolean disposing)
        {
            BusinessObject?.Dispose();

            base.Dispose(disposing);
        }

        // GET: api/values
        [Route("ServiceWatcherItems")]
        public async Task<IActionResult> GetServiceWatcherItems()
        {
            var response = new ListViewModelResponse<ServiceWatcherItemViewModel>() as IListViewModelResponse<ServiceWatcherItemViewModel>;

            try
            {
                var task = await Task.Run(() =>
                {
                    return BusinessObject.GetActiveServiceWatcherItems();
                });

                response.Model = task.Select(item => item.ToViewModel()).ToList();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        [Route("ServiceStatus/{userName}")]
        public async Task<IActionResult> GetServiceStatusDetails(String userName)
        {
            var response = new ListViewModelResponse<ServiceStatusDetailViewModel>() as IListViewModelResponse<ServiceStatusDetailViewModel>;

            try
            {
                var serviceStatuses = await Task.Run(() =>
                {
                    return BusinessObject.GetServiceStatuses(userName);
                });

                response.Model = serviceStatuses.Select(item => item.ToViewModel()).OrderBy(item => item.ServiceName).ToList();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        [Route("ServiceStatus/{id}")]
        public async Task<IActionResult> GetServiceStatus(Int32 id)
        {
            var response = new SingleViewModelResponse<ServiceStatusViewModel>() as ISingleViewModelResponse<ServiceStatusViewModel>;

            try
            {
                var userName = User.Identity.Name;

                var serviceStatus = await Task.Run(() =>
                {
                    return BusinessObject.GetServiceStatus(new ServiceStatus(id));
                });

                response.Model = serviceStatus.ToViewModel();
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
