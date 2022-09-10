using System;
using System.Net.Http;
using System.Threading.Tasks;
using ServiceMonitor.Common.Contracts;

namespace ServiceMonitor.Common.Watchers
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

                    response.Successful = true;
                }
            }
            catch (Exception ex)
            {
                response.ShortMessage = ex.Message;
                response.FullMessage = ex.ToString();
            }

            return response;
        }
    }
}
