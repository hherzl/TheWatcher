using System.Collections.Generic;

namespace ServiceMonitor.Common
{
    public class WatcherParameter
    {
        public WatcherParameter()
        {
        }

        public WatcherParameter(IDictionary<string, string> dictionary)
        {
            Values = dictionary;
        }

        public IDictionary<string, string> Values { get; set; }
    }
}
