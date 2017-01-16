using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMonitor.Common
{
    public class RestClient
    {
        public async Task<String> Get(String url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url);
            }
        }

        public async Task PostStringContent(String url, String content, Encoding encoding, String mediaType)
        {
            using (var httpClient = new HttpClient())
            {
                await httpClient.PostAsync(url, new StringContent(content, encoding, mediaType));
            }
        }
    }
}
