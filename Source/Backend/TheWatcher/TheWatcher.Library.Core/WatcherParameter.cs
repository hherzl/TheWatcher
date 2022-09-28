namespace TheWatcher.Library.Core
{
    public class WatcherParameter
    {
        public const string IPAddress = "IPAddress";
        public const string ConnectionString = "ConnectionString";

        public WatcherParameter()
        {
            Values = new Dictionary<string, string>();
        }

        public WatcherParameter(IDictionary<string, string>? dictionary)
        {
            Values = dictionary;
        }

        public IDictionary<string, string>? Values { get; set; }
    }
}
