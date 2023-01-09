using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TheWatcher.API.Common.Models
{
    public static class Extensions
    {
        public static OkObjectResult ToOkResult(this IResponse response)
            => new (response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
    }
}
