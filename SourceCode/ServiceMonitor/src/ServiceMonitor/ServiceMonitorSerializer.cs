using System;
using Newtonsoft.Json;
using ServiceMonitor.Common;

namespace ServiceMonitor
{
    public class ServiceMonitorSerializer : ISerializer
    {
        public String Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T Deserialze<T>(String source)
        {
            return JsonConvert.DeserializeObject<T>(source);
        }
    }
}
