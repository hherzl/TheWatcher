namespace TheWatcher.Library.Core.Contracts
{
    internal interface IWatcherResult
    {
        bool Successful { get; set; }

        string? ShortMessage { get; set; }

        string? FullMessage { get; set; }
    }
}
