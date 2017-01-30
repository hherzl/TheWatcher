using System;
using System.Text;
using System.Threading.Tasks;
using ServiceMonitor.Common;

namespace ServiceMonitor
{
    public static class RestClientExtensions
    {
        public static async Task PostJsonAsync(this RestClient client, String url, Object obj)
        {
            var serializer = new ServiceMonitorSerializer() as ISerializer;

            var json = serializer.Serialize(obj);

            await client.PostStringContentAsync(url, json, UnicodeEncoding.Unicode, "application/json");
        }
    }
}
