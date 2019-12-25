using System.Net.Http;
using System.Threading.Tasks;
using ServiceMonitor.Clients.Contracts;
using ServiceMonitor.Clients.DataContracts;
using ServiceMonitor.Common.Contracts;

namespace ServiceMonitor.Clients
{
    public class ServiceMonitorClient : IServiceMonitorClient
    {
        readonly HttpClient Client;
        readonly ApiUrl Url;
        readonly ISerializer Serializer;

        public ServiceMonitorClient()
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
