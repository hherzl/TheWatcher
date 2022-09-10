namespace TheWatcher.Library.Core.Contracts
{
    public interface IWatcher
    {
        string ActionName { get; }

        Task<WatchResponse> WatchAsync(WatcherParameter parameter);
    }
}
