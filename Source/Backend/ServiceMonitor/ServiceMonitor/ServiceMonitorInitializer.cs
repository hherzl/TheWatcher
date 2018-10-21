using System.Threading.Tasks;
using ServiceMonitor.Common;
using ServiceMonitor.Models;

namespace ServiceMonitor
{
    public class ServiceMonitorInitializer
    {
        private string json;

        public ServiceMonitorInitializer()
        {
            RestClient = new RestClient();
        }

        public ServiceWatchResponse Response { get; set; }

        public RestClient RestClient { get; }

        public async Task LoadResponseAsync()
        {
            json = await RestClient.GetAsync(AppSettings.ServiceWatcherItemsUrl);
        }

        public void DeserializeResponse()
        {
            var serializer = new ServiceMonitorSerializer();

            Response = serializer.Deserialze<ServiceWatchResponse>(json);
        }
    }
}
