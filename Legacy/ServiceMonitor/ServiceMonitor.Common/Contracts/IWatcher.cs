using System.Threading.Tasks;

namespace ServiceMonitor.Common.Contracts
{
    public interface IWatcher
    {
        string ActionName { get; }

        Task<WatchResponse> WatchAsync(WatcherParameter parameter);
    }
}
