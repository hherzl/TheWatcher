using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Common;

namespace ServiceMonitor
{
    class Program
    {
        static void Main(String[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Trace)
                .AddConsole(LogLevel.Error);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogDebug("Starting application");

            Task.Run(async () =>
            {
                var json = String.Empty;
                var response = default(ServiceWatchResponse);
                var restClient = new RestClient();
                var serializer = new ServiceMonitorSerializer() as ISerializer;

                try
                {
                    json = await restClient.Get(AppSettings.ServiceWatcherItemsUrl);
                }
                catch (Exception ex)
                {
                    logger.LogError("Error on retrieve watch items: {0}", ex);
                    return;
                }

                try
                {
                    response = serializer.Deserialze<ServiceWatchResponse>(json);
                }
                catch (Exception ex)
                {
                    logger.LogError("Error on deserializing object: {0}", ex);
                    return;
                }

                foreach (var item in response.Model)
                {
                    var watcherType = Type.GetType(item.TypeName, true);

                    var watcherInstance = Activator.CreateInstance(watcherType) as IWatcher;

                    var task = Task.Factory.StartNew(async () =>
                    {
                        var controller = new MonitorController(logger, watcherInstance, new RestClient());

                        await controller.Process(item);
                    });
                }

                Console.ReadLine();
            }).Wait();
        }
    }
}
