using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Common;
using ServiceMonitor.Common.Contracts;
using ServiceMonitor.Models;

namespace ServiceMonitor
{
    public class MonitorController
    {
        public MonitorController(AppSettings appSettings, ILogger logger, IWatcher watcher, RestClient restClient)
        {
            AppSettings = appSettings;
            Logger = logger;
            Watcher = watcher;
            RestClient = restClient;
        }

        public AppSettings AppSettings { get; }

        public ILogger Logger { get; }

        public IWatcher Watcher { get; }

        public RestClient RestClient { get; }

        public async Task ProcessAsync(ServiceWatchItem item)
        {
            while (true)
            {
                try
                {
                    Logger?.LogTrace("{0} - Watching '{1}' for '{2}' environment", DateTime.Now, item.ServiceName, item.Environment);

                    var watchResponse = await Watcher.WatchAsync(new WatcherParameter(item.ToDictionary()));

                    if (watchResponse.Success)
                        Logger?.LogInformation(" Success watch for '{0}' in '{1}' environment", item.ServiceName, item.Environment);
                    else
                        Logger?.LogError(" Failed watch for '{0}' in '{1}' environment", item.ServiceName, item.Environment);

                    var watchLog = new ServiceStatusLog
                    {
                        ServiceID = item.ServiceID,
                        ServiceEnvironmentID = item.ServiceEnvironmentID,
                        Target = item.ServiceName,
                        ActionName = Watcher.ActionName,
                        Success = watchResponse.Success,
                        Message = watchResponse.Message,
                        StackTrace = watchResponse.StackTrace
                    };

                    try
                    {
                        await RestClient.PostJsonAsync(AppSettings.ServiceStatusLogUrl, watchLog);
                    }
                    catch (Exception ex)
                    {
                        Logger?.LogError(" Error on saving watch response ({0}): '{1}'", item.ServiceName, ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Logger?.LogError(" Error watching service: '{0}': '{1}'", item.ServiceName, ex.Message);
                }

                Thread.Sleep(item.Interval ?? AppSettings.DelayTime);
            }
        }
    }
}
