using Microsoft.AspNetCore.Http.Features;

namespace TheWatcher.API.Monitor
{
    public class MonitorService : IHostedService, IDisposable
    {
        private readonly ILogger<MonitorService> _logger;
        private List<Timer>? _timers;

        public MonitorService(ILogger<MonitorService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("Starting monitor...");

            _timers = new List<Timer>
            {
                new Timer(Monitoring, 0, TimeSpan.Zero, TimeSpan.FromSeconds(5)),
                new Timer(Monitoring, 1, TimeSpan.Zero, TimeSpan.FromSeconds(15))
            };

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

        public void Monitoring(object? state)
        {
            _logger.LogInformation($"Monitor {state} is working...");
        }
    }
}
