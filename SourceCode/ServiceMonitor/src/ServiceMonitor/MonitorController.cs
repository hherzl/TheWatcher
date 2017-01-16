using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Common;

namespace ServiceMonitor
{
    public class MonitorController
    {
        public MonitorController(ILogger logger, IWatcher watcher, RestClient restClient)
        {
            Logger = logger;
            Watcher = watcher;
            RestClient = restClient;
        }

        public ILogger Logger { get; }

        public IWatcher Watcher { get; }

        public RestClient RestClient { get; }

        public async Task Process(ServiceWatchItem item)
        {
            while (true)
            {
                try
                {
                    Logger.LogTrace("{0} - Watching '{1}'", DateTime.Now, item.ServiceName);

                    var watchResponse = await Watcher.Watch(new WatcherParameter { Values = item.ToDictionary() });

                    var watchLog = new ServiceStatusLog
                    {
                        ServiceID = item.ServiceID,
                        Target = item.ServiceName,
                        ActionName = Watcher.ActionName,
                        Success = watchResponse.Success,
                        Message = watchResponse.Message,
                        StackTrace = watchResponse.StackTrace
                    };

                    try
                    {
                        await RestClient.PostJson(AppSettings.ServiceStatusLogUrl, watchLog);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(" Error on saving watch response ({0}): '{1}'", item.ServiceName, ex);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(" Error on watch: '{0}'", ex);
                }

                Thread.Sleep(item.Interval.HasValue ? item.Interval.Value : AppSettings.DelayTime);
            }
        }
    }
}
