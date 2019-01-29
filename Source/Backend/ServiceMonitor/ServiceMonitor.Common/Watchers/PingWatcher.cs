using System.Net.NetworkInformation;
using System.Threading.Tasks;
using ServiceMonitor.Common.Contracts;

namespace ServiceMonitor.Common
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
                    Success = reply.Status == IPStatus.Success ? true : false
                };
            }
        }
    }
}
