using System;

namespace ServiceMonitor.Common
{
    public interface ISerializer
    {
        String Serialize<T>(T obj);

        T Deserialze<T>(String source);
    }
}
