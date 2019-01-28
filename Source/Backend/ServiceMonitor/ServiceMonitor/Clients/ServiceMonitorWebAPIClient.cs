using System.Net.Http;
using System.Threading.Tasks;
using ServiceMonitor.Clients.Models;
using ServiceMonitor.Common.Contracts;

namespace ServiceMonitor.Clients
{
    public class ServiceMonitorWebAPIClient : IServiceMonitorWebAPIClient
    {
        private readonly HttpClient Client;
        private readonly ApiUrl Url;
        private readonly ISerializer Serializer;

        public ServiceMonitorWebAPIClient()
        {
            Client = new HttpClient();
            Url = new ApiUrl(baseUrl: "http://localhost:10000");
            Serializer = new ServiceMonitorSerializer();
        }

        public async Task<ServiceWatchResponse> GetServiceWatcherItemsAsync()
        {
            var response = await Client.GetAsync(
                Url.Controller("Dashboard").Action("ServiceWatcherItem").ToString()
            );

            var content = await response.Content.ReadAsStringAsync();

            return Serializer.Deserialze<ServiceWatchResponse>(content);
        }

        public async Task<HttpResponseMessage> PostServiceEnvironmentStatusLog(ServiceStatusLogRequest request)
            => await Client.PostAsync(
                Url.Controller("Administration").Action("ServiceEnvironmentStatusLog").ToString(),
                ContentHelper.GetStringContent(request)
            );
    }
}
