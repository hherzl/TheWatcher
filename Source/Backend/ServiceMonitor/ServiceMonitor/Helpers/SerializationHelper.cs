using Newtonsoft.Json;

namespace ServiceMonitor.Helpers
{
    public static class SerializationHelper
    {
        public static string Serialize<T>(T obj)
            => JsonConvert.SerializeObject(obj);

        public static T Deserialze<T>(string source)
            => JsonConvert.DeserializeObject<T>(source);
    }
}
