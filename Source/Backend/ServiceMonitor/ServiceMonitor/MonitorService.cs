using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Clients.Contracts;
using ServiceMonitor.Clients.DataContracts;
using ServiceMonitor.Common;
using ServiceMonitor.Common.Contracts;

namespace ServiceMonitor
{
    public class MonitorService
    {
        public MonitorService(ILogger logger, IWatcher watcher, IServiceMonitorClient client, AppSettings appSettings)
        {
            Logger = logger;
            Watcher = watcher;
            Client = client;
            AppSettings = appSettings;
        }

        public ILogger Logger { get; }

        public IWatcher Watcher { get; }

        public IServiceMonitorClient Client { get; }

        public AppSettings AppSettings { get; }

        public async Task ProcessAsync(ServiceWatchItem item)
        {
            while (true)
            {
                try
                {
                    Logger?.LogTrace("{0} - Watching '{1}' for '{2}' environment", DateTime.Now, item.ServiceName, item.Environment);

                    var watchResponse = await Watcher.WatchAsync(new WatcherParameter(item.ToDictionary()));

                    if (watchResponse.Successful)
                        Logger?.LogInformation(" Success watch for '{0}' in '{1}' environment", item.ServiceName, item.Environment);
                    else
                        Logger?.LogError(" Failed watch for '{0}' in '{1}' environment", item.ServiceName, item.Environment);

                    var serviceStatusLog = new ServiceStatusLogRequest
                    {
                        ServiceID = item.ServiceID,
                        ServiceEnvironmentID = item.ServiceEnvironmentID,
                        Target = item.ServiceName,
                        ActionName = Watcher.ActionName,
                        Successful = watchResponse.Successful,
                        ShortMessage = watchResponse.ShortMessage,
                        FullMessage = watchResponse.FullMessage
                    };

                    try
                    {
                        await Client.PostServiceEnvironmentStatusLog(serviceStatusLog);
                    }
                    catch (Exception ex)
                    {
                        Logger?.LogCritical(" Error on saving watch response ({0}): '{1}'", item.ServiceName, ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Logger?.LogCritical(" Error watching service: '{0}': '{1}'", item.ServiceName, ex.Message);
                }

                Thread.Sleep(item.Interval ?? AppSettings.DelayTime);
            }
        }
    }
}
