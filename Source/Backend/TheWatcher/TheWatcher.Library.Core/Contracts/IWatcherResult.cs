namespace TheWatcher.Library.Core.Contracts
{
    public interface IWatcherResult
    {
        bool Successful { get; set; }

        string? Message { get; set; }

        string? ErrorMessage { get; set; }
    }
}
