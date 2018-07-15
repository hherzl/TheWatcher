using System.Text;
using System.Threading.Tasks;
using ServiceMonitor.Common;

namespace ServiceMonitor
{
    public static class RestClientExtensions
    {
        public static async Task PostJsonAsync(this RestClient client, string url, object obj)
        {
            var serializer = new ServiceMonitorSerializer();

            var json = serializer.Serialize(obj);

            await client.PostStringContentAsync(url, json, Encoding.Unicode, "application/json");
        }
    }
}
