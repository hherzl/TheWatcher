using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceMonitor.Clients;
using ServiceMonitor.Clients.DataContracts;
using ServiceMonitor.Common;
using ServiceMonitor.Common.Contracts;

namespace ServiceMonitor
{
    class Program
    {
        private static ILogger Logger;
        private static readonly AppSettings AppSettings;

        static Program()
        {
            Logger = LoggingHelper.GetLogger<Program>();

            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            AppSettings = new AppSettings();

            configuration.GetSection("appSettings").Bind(AppSettings);
        }

        static void Main(string[] args)
        {
            StartAsync(args).GetAwaiter().GetResult();

            Console.ReadLine();
        }

        static async Task StartAsync(string[] args)
        {
            Logger.LogDebug("Starting service monitor...");

            var client = new ServiceMonitorWebAPIClient();

            var serviceWatcherItemsResponse = default(ServiceWatchResponse);

            try
            {
                serviceWatcherItemsResponse = await client.GetServiceWatcherItemsAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError("Error on retrieve watch items: {0}", ex);
                return;
            }

            foreach (var item in serviceWatcherItemsResponse.Model)
            {
                var watcherType = Type.GetType(item.TypeName, true);

                var watcherInstance = Activator.CreateInstance(watcherType) as IWatcher;

                await Task.Factory.StartNew(async () =>
                {
                    var controller = new MonitorController(Logger, watcherInstance, client, AppSettings);

                    await controller.ProcessAsync(item);
                });
            }
        }
    }
}
