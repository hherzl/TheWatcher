using System.Net.NetworkInformation;
using TheWatcher.Library.Core;
using TheWatcher.Library.Core.Contracts;

namespace TheWatcher.Watcher.PingWatcher
{
    public class PingWatcher : IWatcher
    {
        public string ActionName
            => "Ping";

        public async Task<WatcherResult> WatchAsync(WatcherParameter parameter)
        {
            var ping = new Ping();

            var reply = await ping.SendPingAsync(parameter.Values[WatcherParameter.IPAddress]);

            return new WatcherResult
            {
                Successful = reply.Status == IPStatus.Success ? true : false,
                Message = reply.Status == IPStatus.Success ? "Successful ping" : "Failed ping"
            };
        }
    }
}
