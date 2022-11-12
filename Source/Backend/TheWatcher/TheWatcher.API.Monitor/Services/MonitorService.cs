using TheWatcher.API.Monitor.Services.Models;
using TheWatcher.Domain.Core;
using TheWatcher.Library.Core;
using TheWatcher.Library.Core.Contracts;

namespace TheWatcher.API.Monitor.Services
{
    public class MonitorService : IHostedService, IDisposable
    {
        private readonly ILogger<MonitorService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private List<Timer>? _timers;

        public MonitorService(ILogger<MonitorService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("Starting monitor...");

            _timers = new List<Timer>();

            var scope = _serviceScopeFactory.CreateScope();

            using var ctx = scope.ServiceProvider.GetService<TheWatcherDbContext>();

            var resourcesWatches =
                from resourceWatch in ctx.ResourceWatch
                join resource in ctx.Resource on resourceWatch.ResourceId equals resource.Id
                join resourceCategory in ctx.ResourceCategory on resource.ResourceCategoryId equals resourceCategory.Id
                join watcher in ctx.Watcher on resourceCategory.WatcherId equals watcher.Id
                join environment in ctx.Environment on resourceWatch.EnvironmentId equals environment.Id
                select new ResourceWatchItemModel
                {
                    Id = resourceWatch.Id,
                    Resource = resource.Name,
                    ResourceCategory = resourceCategory.Name,
                    AssemblyQualifiedName = watcher.AssemblyQualifiedName,
                    Interval = resourceWatch.Interval,
                    Environment = environment.Name
                };

            var list = resourcesWatches.ToList();

            foreach (var resourceWatch in list)
            {
                resourceWatch.Parameter = new WatcherParameter();

                var parameters = ctx.ResourceWatchParameter.Where(x => x.ResourceWatchId == resourceWatch.Id).ToList();

                foreach (var param in parameters)
                {
                    resourceWatch.Parameter.Values.Add(param.Parameter, param.Value);
                }

                _timers.Add(new Timer(Monitoring, resourceWatch, TimeSpan.Zero, TimeSpan.FromMilliseconds((double)resourceWatch.Interval)));
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("Stopping monitor...");

            foreach (var item in _timers)
            {
                item?.Change(Timeout.Infinite, 0);
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            foreach (var item in _timers)
            {
                item?.Dispose();
            }
        }

        public async void Monitoring(object? state)
        {
            if (state is ResourceWatchItemModel cast)
            {
                _logger.LogInformation($"Monitor for '{cast.Resource}' resource is working in '{cast.Environment}' environment, interval: '{cast.Interval}'...");

                var watcherType = Type.GetType(cast.AssemblyQualifiedName, true);

                var watcherInstance = (IWatcher)Activator.CreateInstance(watcherType);

                await Task.Factory.StartNew(async () =>
                {
                    var result = await watcherInstance.WatchAsync(cast.Parameter);

                    _logger.LogInformation($"The watch for '{cast.Resource}' was '{(result.Successful ? "Successfully" : "Failed")}'");

                    // todo: save result in database
                });
            }
        }
    }
}
