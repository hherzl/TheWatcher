using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ServiceMonitor.Common
{
    public static class LoggerHelper
    {
        public static ILogger<T> GetLogger<T>() where T : class
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug)
                .AddConsole(LogLevel.Trace)
                .AddConsole(LogLevel.Information)
                .AddConsole(LogLevel.Warning)
                .AddConsole(LogLevel.Critical)
                .AddConsole(LogLevel.Error);

            return serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger<T>();
        }
    }
}
