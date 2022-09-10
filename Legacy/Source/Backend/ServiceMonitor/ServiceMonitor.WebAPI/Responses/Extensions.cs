using System.Net;
using Microsoft.AspNetCore.Mvc;
using ServiceMonitor.Core.Business.Responses.Contracts;

namespace ServiceMonitor.WebAPI.Responses
{
#pragma warning disable CS1591
    public static class Extensions
    {
        public static IActionResult ToHttpResponse<TModel>(this IListResponse<TModel> response) where TModel : class
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NoContent;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpCreatedResponse<TModel>(this ISingleResponse<TModel> response) where TModel : class
        {
            var status = response.DidError ? HttpStatusCode.InternalServerError : HttpStatusCode.Created;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
    }
#pragma warning restore CS1591
}
