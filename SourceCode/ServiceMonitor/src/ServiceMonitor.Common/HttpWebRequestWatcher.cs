using System;
using System.Threading.Tasks;

namespace ServiceMonitor.Common
{
    public class HttpWebRequestWatcher : IWatcher
    {
        public HttpWebRequestWatcher()
        {
        }

        public String ActionName => "HttpRequest";

        public async Task<WatchResponse> Watch(WatcherParameter parameter)
        {
            var response = new WatchResponse();

            try
            {
                var restClient = new RestClient();

                await restClient.Get(parameter.Values["Url"]);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.StackTrace = ex.ToString();
            }

            return response;
        }
    }
}
