using System;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Core.BusinessLayer.Responses;

namespace ServiceMonitor.Core.BusinessLayer
{
    public static class ResponseExtensions
    {
        public static void SetError(this IResponse response, ILogger logger, Exception ex)
        {
            response.DidError = true;
            response.ErrorMessage = ex.Message;

            logger?.LogError(ex.Message);
        }
    }
}
