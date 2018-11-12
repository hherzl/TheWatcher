using System.Net.Http;
using System.Text;

namespace ServiceMonitor
{
    public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
        {
            var serializer = new ServiceMonitorSerializer();

            return new StringContent(serializer.Serialize(obj), Encoding.Unicode, "application/json");
        }
    }
}
