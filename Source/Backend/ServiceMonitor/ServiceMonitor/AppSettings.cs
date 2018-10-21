using System;
using Microsoft.Extensions.Configuration;

namespace ServiceMonitor
{
    public static class AppSettings
    {
        static AppSettings()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            ServiceWatcherItemsUrl = configuration["serviceWatcherItemsUrl"];
            ServiceStatusLogUrl = configuration["serviceStatusLogUrl"];
            DelayTime = Convert.ToInt32(configuration["delayTime"]);
        }

        public static readonly string ServiceWatcherItemsUrl;
        public static readonly string ServiceStatusLogUrl;
        public static readonly int DelayTime;
    }
}
