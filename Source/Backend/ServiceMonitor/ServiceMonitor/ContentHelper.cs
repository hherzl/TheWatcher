using System.Net.Http;
using System.Text;

namespace ServiceMonitor
{
    public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
            => new StringContent(new ServiceMonitorSerializer().Serialize(obj), Encoding.Default, "application/json");
    }
}
