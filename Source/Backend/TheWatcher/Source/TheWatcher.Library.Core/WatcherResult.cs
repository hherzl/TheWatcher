using TheWatcher.Library.Core.Contracts;

namespace TheWatcher.Library.Core
{
    public class WatcherResult : IWatcherResult
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
