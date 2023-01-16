namespace TheWatcher.Library.Core.Contracts
{
    public interface IWatcherResult
    {
        bool IsSuccess { get; set; }

        string? Message { get; set; }

        string? ErrorMessage { get; set; }
    }
}
