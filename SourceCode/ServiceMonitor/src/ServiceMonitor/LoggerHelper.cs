using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ServiceMonitor
{
    public static class LoggerHelper
    {
        public static ILogger<T> GetLogger<T>()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Trace)
                .AddConsole(LogLevel.Error)
                .AddConsole(LogLevel.Critical);

            return serviceProvider.GetService<ILoggerFactory>().CreateLogger<T>();
        }
    }
}
