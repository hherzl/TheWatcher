namespace ServiceMonitor.Common
{
    public interface IWatchResponse
    {
        bool Success { get; set; }

        string Message { get; set; }

        string StackTrace { get; set; }
    }
}
