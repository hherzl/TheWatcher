using System;

namespace ServiceMonitor.Common
{
    public class WatchResponse : IWatchResponse
    {
        public Boolean Success { get; set; }

        public String Message { get; set; }

        public String StackTrace { get; set; }
    }
}
