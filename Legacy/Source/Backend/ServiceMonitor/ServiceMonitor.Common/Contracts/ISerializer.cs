namespace ServiceMonitor.Common.Contracts
{
    public interface ISerializer
    {
        string Serialize<T>(T obj);

        T Deserialze<T>(string source);
    }
}
