using System.Net.NetworkInformation;
using TheWatcher.Library.Core;
using TheWatcher.Library.Core.Contracts;

namespace TheWatcher.Watchers.PingWatcher
{
    public class PingWatcher : IWatcher
    {
        private static readonly Guid ClassGuid = new("75B0AD20-A454-41E9-9FDA-AD065A7A95DD");

        public Guid Guid
            => ClassGuid;

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
