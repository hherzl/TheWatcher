using System;
using System.Threading.Tasks;

namespace ServiceMonitor.Common
{
    public interface IWatcher
    {
        String ActionName { get; }

        Task<WatchResponse> Watch(WatcherParameter parameter);
    }
}
