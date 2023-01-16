﻿using TheWatcher.API.Monitor.Services.Models;
using TheWatcher.Domain.Core;
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
            _logger.LogDebug("Starting watchers...");

            _timers = new List<Timer>();

            var scope = _serviceScopeFactory.CreateScope();

            using var dbContext = scope.ServiceProvider.GetService<TheWatcherDbContext>();

            var list = dbContext.GetResourceWatchItems().ToList();

            var model = list
                .Select(item => new ResourceWatchItemModel
                {
                    Id = item.Id,
                    Resource = item.Resource,
                    ResourceCategory = item.ResourceCategory,
                    AssemblyQualifiedName = item.AssemblyQualifiedName,
                    Environment = item.Environment,
                    Interval = item.Interval
                })
                .ToList()
                ;

            foreach (var resourceWatchItem in model)
            {
                var parameters = dbContext
                    .ResourceWatchParameter
                    .Where(x => x.ResourceWatchId == resourceWatchItem.Id)
                    .ToList()
                    ;

                foreach (var param in parameters)
                {
                    resourceWatchItem.Param.Values.Add(param.Parameter, param.Value);
                }

                _timers.Add(new Timer(Monitoring, resourceWatchItem, TimeSpan.Zero, TimeSpan.FromMilliseconds((double)resourceWatchItem.Interval)));
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("Stopping watchers...");

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
                _logger.LogInformation($"Watcher for '{cast.Resource}' resource is executing in '{cast.Environment}' environment, interval: '{cast.Interval}'...");

                var watcherType = Type.GetType(cast.AssemblyQualifiedName, true);

                var watcherInstance = (IWatcher)Activator.CreateInstance(watcherType);

                await Task.Factory.StartNew(async () =>
                {
                    var result = await watcherInstance.WatchAsync(cast.Param);

                    if (result.Successful)
                        _logger.LogInformation($"The watch for '{cast.Resource}' was 'Successfully' in '{cast.Environment}'");
                    else
                        _logger.LogError($"The watch for '{cast.Resource}' was 'Failed' in '{cast.Environment}'");

                    // todo: save result in database
                });
            }
        }
    }
}