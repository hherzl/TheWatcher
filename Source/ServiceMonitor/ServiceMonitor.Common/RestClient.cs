using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMonitor.Common
{
    public class RestClient
    {
        public async Task<string> GetAsync(string url)
        {
            using (var httpClient = new HttpClient())
                return await httpClient.GetStringAsync(url);
        }

        public async Task PostStringContentAsync(string url, string content, Encoding encoding, string mediaType)
        {
            using (var httpClient = new HttpClient())
                await httpClient.PostAsync(url, new StringContent(content, encoding, mediaType));
        }
    }
}
