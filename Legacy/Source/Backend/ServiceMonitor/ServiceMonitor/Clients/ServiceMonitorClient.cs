using System.Net.Http;
using System.Threading.Tasks;
using ServiceMonitor.Clients.Contracts;
using ServiceMonitor.Clients.DataContracts;
using ServiceMonitor.Helpers;

namespace ServiceMonitor.Clients
{
    public class ServiceMonitorClient : IServiceMonitorClient
    {
        readonly HttpClient Client;
        readonly ApiUrl Url;

        public ServiceMonitorClient()
        {
            Client = new HttpClient();

            Url = new ApiUrl(baseUrl: "http://localhost:10000");
        }

        public async Task<ServiceWatchResponse> GetServiceWatcherItemsAsync()
        {
            var url = Url
                .Controller("Dashboard")
                .Action("ServiceWatcherItem")
                .ToString();

            var response = await Client.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();

            return SerializationHelper.Deserialze<ServiceWatchResponse>(content);
        }

        public async Task<HttpResponseMessage> PostServiceEnvironmentStatusLog(ServiceStatusLogRequest request)
        {
            var url = Url
                .Controller("Administration")
                .Action("ServiceEnvironmentStatusLog")
                .ToString();

            return await Client.PostAsync(url, ContentHelper.GetStringContent(request));
        }
    }
}
