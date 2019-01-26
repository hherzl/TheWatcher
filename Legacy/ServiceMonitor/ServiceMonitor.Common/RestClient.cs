using System.Net.Http;
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

        public async Task PostStringContentAsync(string url, StringContent content)
        {
            using (var httpClient = new HttpClient())
                await httpClient.PostAsync(url, content);
        }
    }
}
