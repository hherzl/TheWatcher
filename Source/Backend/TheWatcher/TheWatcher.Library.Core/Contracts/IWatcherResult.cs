namespace TheWatcher.Library.Core.Contracts
{
    internal interface IWatcherResult
    {
        bool Successful { get; set; }

        string? Message { get; set; }

        string? ErrorMessage { get; set; }
    }
}
