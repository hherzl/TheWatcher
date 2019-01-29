using System;
using System.Net.Http;
using System.Threading.Tasks;
using ServiceMonitor.Common.Contracts;

namespace ServiceMonitor.Common
{
    public class HttpRequestWatcher : IWatcher
    {
        public string ActionName
            => "HttpRequest";

        public async Task<WatchResponse> WatchAsync(WatcherParameter parameter)
        {
            var response = new WatchResponse();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    await httpClient.GetAsync(parameter.Values["Url"]);

                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StackTrace = ex.ToString();
            }

            return response;
        }
    }
}
