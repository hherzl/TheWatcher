using ServiceMonitor.Common.Contracts;

namespace ServiceMonitor.Common
{
    public class WatchResponse : IWatchResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }
    }
}
