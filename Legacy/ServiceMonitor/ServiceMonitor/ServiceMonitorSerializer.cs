using Newtonsoft.Json;
using ServiceMonitor.Common.Contracts;

namespace ServiceMonitor
{
    public class ServiceMonitorSerializer : ISerializer
    {
        public string Serialize<T>(T obj)
            => JsonConvert.SerializeObject(obj);

        public T Deserialze<T>(string source)
            => JsonConvert.DeserializeObject<T>(source);
    }
}
