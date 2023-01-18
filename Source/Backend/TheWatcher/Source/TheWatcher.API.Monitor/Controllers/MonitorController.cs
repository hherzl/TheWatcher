using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWatcher.API.Common.Models;
using TheWatcher.API.Common.Models.Contracts;
using TheWatcher.API.Monitor.Models;
using TheWatcher.Domain.Core;

namespace TheWatcher.API.Monitor.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class MonitorController : ControllerBase
    {
        private readonly ILogger<MonitorController> _logger;
        private readonly TheWatcherDbContext _dbContext;

        public MonitorController(ILogger<MonitorController> logger, TheWatcherDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("monitor")]
        [ProducesResponseType(200, Type = typeof(IListResponse<ResourceWatchItemModel>))]
        public async Task<IActionResult> GetMonitorAsync()
        {
            var response = new ListResponse<ResourceWatchItemModel>();

            var resourceWatches =
                from resourceWatch in _dbContext.ResourceWatch
                join resource in _dbContext.Resource on resourceWatch.ResourceId equals resource.Id
                join environment in _dbContext.Environment on resourceWatch.EnvironmentId equals environment.Id
                select new ResourceWatchItemModel
                {
                    ResourceId = resourceWatch.ResourceId,
                    Resource = resource.Name,
                    EnvironmentId = resourceWatch.EnvironmentId,
                    Environment = environment.Name,
                    Successful = resourceWatch.Successful,
                    WatchCount = resourceWatch.WatchCount,
                    LastWatch = resourceWatch.LastWatch,
                    Interval = resourceWatch.Interval
                };

            response.Model = await resourceWatches.ToListAsync();

            return response.ToOkResult();
        }
    }
}
