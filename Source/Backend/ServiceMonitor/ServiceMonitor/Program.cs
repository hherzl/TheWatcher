using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Common;
using ServiceMonitor.Common.Contracts;

namespace ServiceMonitor
{
    class Program
    {
        private static ILogger logger;
        private static readonly AppSettings appSettings;

        static Program()
        {
            logger = LoggingHelper.GetLogger<Program>();

            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            appSettings = new AppSettings
            {
                ServiceWatcherItemsUrl = configuration["serviceWatcherItemUrl"],
                ServiceStatusLogUrl = configuration["serviceStatusLogUrl"],
                DelayTime = Convert.ToInt32(configuration["delayTime"])
            };
        }

        static void Main(string[] args)
        {
            StartAsync(args).GetAwaiter().GetResult();

            Console.ReadLine();
        }

        static async Task StartAsync(string[] args)
        {
            logger.LogDebug("Starting application...");

            var initializer = new ServiceMonitorInitializer(appSettings);

            try
            {
                await initializer.LoadResponseAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("Error on retrieve watch items: {0}", ex);
                return;
            }

            try
            {
                initializer.DeserializeResponse();
            }
            catch (Exception ex)
            {
                logger.LogError("Error on deserializing object: {0}", ex);
                return;
            }

            foreach (var item in initializer.Response.Model)
            {
                var watcherType = Type.GetType(item.TypeName, true);

                var watcherInstance = Activator.CreateInstance(watcherType) as IWatcher;

                var task = Task.Factory.StartNew(async () =>
                {
                    var controller = new MonitorController(appSettings, logger, watcherInstance, initializer.RestClient);

                    await controller.ProcessAsync(item);
                });
            }
        }
    }
}
