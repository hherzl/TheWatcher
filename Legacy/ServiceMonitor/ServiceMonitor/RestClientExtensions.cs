using System.Threading.Tasks;
using ServiceMonitor.Common;

namespace ServiceMonitor
{
    public static class RestClientExtensions
    {
        public static async Task PostJsonAsync(this RestClient client, string url, object obj)
        {
            await client.PostStringContentAsync(url, ContentHelper.GetStringContent(obj));
        }
    }
}
