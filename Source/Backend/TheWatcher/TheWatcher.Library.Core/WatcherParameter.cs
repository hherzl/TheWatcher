namespace TheWatcher.Library.Core
{
    public class WatcherParameter
    {
        public const string? ConnectionString = "ConnectionString";

        public WatcherParameter()
        {
        }

        public WatcherParameter(IDictionary<string, string>? dictionary)
        {
            Values = dictionary;
        }

        public IDictionary<string, string>? Values { get; set; }
    }
}
