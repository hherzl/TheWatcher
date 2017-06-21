using System;
using Newtonsoft.Json;
using ServiceMonitor.Common;

namespace ServiceMonitor
{
    public class ServiceMonitorSerializer : ISerializer
    {
        public String Serialize<T>(T obj)
            => JsonConvert.SerializeObject(obj);

        public T Deserialze<T>(String source)
            => JsonConvert.DeserializeObject<T>(source);
    }
}
