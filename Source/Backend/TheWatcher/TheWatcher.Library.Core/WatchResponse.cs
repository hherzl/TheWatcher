using TheWatcher.Library.Core.Contracts;

namespace TheWatcher.Library.Core
{
    public class WatchResponse : IWatchResponse
    {
        public bool Successful { get; set; }

        public string? ShortMessage { get; set; }

        public string? FullMessage { get; set; }
    }
}
