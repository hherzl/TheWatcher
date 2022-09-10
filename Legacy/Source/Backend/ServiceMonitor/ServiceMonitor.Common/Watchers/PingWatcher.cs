using System.Net.NetworkInformation;
using System.Threading.Tasks;
using ServiceMonitor.Common.Contracts;

namespace ServiceMonitor.Common.Watchers
{
    public class PingWatcher : IWatcher
    {
        public string ActionName
            => "Ping";

        public async Task<WatchResponse> WatchAsync(WatcherParameter parameter)
        {
            using (var ping = new Ping())
            {
                var reply = await ping.SendPingAsync(parameter.Values["Address"]);

                return new WatchResponse
                {
                    Successful = reply.Status == IPStatus.Success ? true : false,
                    ShortMessage = reply.Status == IPStatus.Success ? "Successful ping" : "Failed ping"
                };
            }
        }
    }
}
