using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ServiceMonitor.Common
{
    public static class LoggingHelper
    {
        public static ILogger<TModel> GetLogger<TModel>()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            return serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger<TModel>();
        }
    }
}
