namespace ServiceMonitor.Common.Contracts
{
    public interface IWatchResponse
    {
        bool Successful { get; set; }

        string ShortMessage { get; set; }

        string FullMessage { get; set; }
    }
}
