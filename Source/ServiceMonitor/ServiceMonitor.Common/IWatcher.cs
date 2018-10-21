using System.Threading.Tasks;

namespace ServiceMonitor.Common
{
    public interface IWatcher
    {
        string ActionName { get; }

        Task<WatchResponse> WatchAsync(WatcherParameter parameter);
    }
}
