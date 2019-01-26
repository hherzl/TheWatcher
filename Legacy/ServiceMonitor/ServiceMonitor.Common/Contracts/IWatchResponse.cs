namespace ServiceMonitor.Common.Contracts
{
    public interface IWatchResponse
    {
        bool Success { get; set; }

        string Message { get; set; }

        string StackTrace { get; set; }
    }
}
