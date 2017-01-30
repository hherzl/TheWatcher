using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMonitor.Common
{
    public class RestClient
    {
        public async Task<String> GetAsync(String url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url);
            }
        }

        public async Task PostStringContentAsync(String url, String content, Encoding encoding, String mediaType)
        {
            using (var httpClient = new HttpClient())
            {
                await httpClient.PostAsync(url, new StringContent(content, encoding, mediaType));
            }
        }
    }
}
