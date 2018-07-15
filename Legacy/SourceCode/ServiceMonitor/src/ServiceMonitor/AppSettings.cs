using System;
using Microsoft.Framework.Configuration;

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

        public static readonly String ServiceWatcherItemsUrl;
        public static readonly String ServiceStatusLogUrl;
        public static readonly Int32 DelayTime;
    }
}
