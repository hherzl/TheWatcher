using System;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Core.BusinessLayer.Responses;

namespace ServiceMonitor.Core.BusinessLayer
{
    public static class ResponseExtensions
    {
        public static void SetError<TModel>(this IListResponse<TModel> response, ILogger logger, Exception ex)
        {
            response.DidError = true;
            response.ErrorMessage = ex.Message;

            logger?.LogError(ex.Message);
        }

        public static void SetError<TModel>(this ISingleResponse<TModel> response, ILogger logger, Exception ex)
        {
            response.DidError = true;
            response.ErrorMessage = ex.Message;

            logger?.LogError(ex.Message);
        }
    }
}
