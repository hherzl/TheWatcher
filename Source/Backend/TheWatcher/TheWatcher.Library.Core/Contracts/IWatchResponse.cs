namespace TheWatcher.Library.Core.Contracts
{
    internal interface IWatchResponse
    {
        bool Successful { get; set; }

        string? ShortMessage { get; set; }

        string? FullMessage { get; set; }
    }
}
