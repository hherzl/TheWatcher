namespace TheWatcher.Library.Core.Contracts
{
    public interface IWatcher
    {
        string ActionName { get; }

        Task<WatcherResult> WatchAsync(WatcherParameter parameter);
    }
}
