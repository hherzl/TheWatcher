using System.Net.Http;
using System.Text;

namespace ServiceMonitor.Helpers
{
    public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
            => new StringContent(SerializationHelper.Serialize(obj), Encoding.Default, "application/json");
    }
}
