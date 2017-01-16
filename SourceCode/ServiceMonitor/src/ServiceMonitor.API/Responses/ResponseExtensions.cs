using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ServiceMonitor.Responses;

namespace ServiceMonitor.API.Responses
{
    public static class ResponseExtensions
    {
        public static IActionResult ToHttpResponse<TModel>(this IListViewModelResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.Model == null)
            {
                status = HttpStatusCode.NoContent;
            }

            return new ObjectResult(response) { StatusCode = (Int32)status };
        }

        public static IActionResult ToHttpResponse<TModel>(this ISingleViewModelResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.Model == null)
            {
                status = HttpStatusCode.NotFound;
            }

            return new ObjectResult(response) { StatusCode = (Int32)status };
        }
    }
}
