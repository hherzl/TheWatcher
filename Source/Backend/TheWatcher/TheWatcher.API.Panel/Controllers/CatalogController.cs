using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWatcher.API.Common.Models;
using TheWatcher.API.Panel.Models;
using TheWatcher.Domain.Core;

namespace TheWatcher.API.Panel.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly TheWatcherDbContext _dbContext;

        public CatalogController(ILogger<CatalogController> logger, TheWatcherDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("watcher")]
        public async Task<IActionResult> GetWatchersAsync()
        {
            var response = new ListResponse<WatcherItemModel>();

            var watchers =
                from watcher in _dbContext.Watcher
                select new WatcherItemModel
                {
                    Id = watcher.Id,
                    Name = watcher.Name,
                    Description = watcher.Description
                };

            response.Model = await watchers.ToListAsync();

            return response.ToOkResult();
        }

        [HttpGet("watcher/{id}")]
        public async Task<IActionResult> GetWatcherAsync(short? id)
        {
            var entity = await _dbContext.Watcher.Include(e => e.WatcherParameterList).FirstOrDefaultAsync(item => item.Id == id);

            if (entity == null)
                return NotFound();

            var value = new
            {
                Id = entity.Id,
                Guid = entity.Guid,
                AssemblyQualifiedName = entity.AssemblyQualifiedName,
                Name = entity.Name,
                Description = entity.Description,
                Parameters = entity.WatcherParameterList.Select(item => new { item.Id, item.IsDefault, item.Parameter, item.Value, item.Description }).ToList()
            };

            return Ok(value);
        }

        [HttpGet("resource")]
        public async Task<IActionResult> GetResourcesAsync()
        {
            var resources =
                from resource in _dbContext.Resource
                join category in _dbContext.ResourceCategory on resource.ResourceCategoryId equals category.Id
                select new
                {
                    Id = resource.Id,
                    Name = resource.Name,
                    ResourceCategoryId = resource.ResourceCategoryId,
                    ResourceCategory = category.Name
                };

            var list = await resources.ToListAsync();

            return Ok(list);
        }

        [HttpGet("resource/{id}")]
        public async Task<IActionResult> GetResourceAsync(short? id)
        {
            var entity = await _dbContext
                .Resource
                .Include(e => e.ResourceCategoryFk.WatcherFk)
                .Include(e => e.ResourceWatchList)
                    .ThenInclude(e => e.EnvironmentFk)
                .Include(e => e.ResourceWatchList)
                    .ThenInclude(e => e.ResourceWatchParameterList)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (entity == null)
                return NotFound();

            var value = new
            {
                Id = entity.Id,
                Name = entity.Name,
                ResourceCategoryId = entity.ResourceCategoryId,
                ResourceCategory = entity.ResourceCategoryFk.Name,
                WatcherId = entity.ResourceCategoryFk.WatcherId,
                Watcher = entity.ResourceCategoryFk.WatcherFk.Name,
                Watches = entity.ResourceWatchList.Select(watch => new
                {
                    watch.Id,
                    watch.EnvironmentId,
                    Environment = watch.EnvironmentFk.Name,
                    watch.Successful,
                    watch.WatchCount,
                    watch.LastWatch, watch.Interval,
                    Parameters = watch.ResourceWatchParameterList.Select(parameter => new { parameter.Parameter, parameter.Value, parameter.Description }).ToList()
                }).ToList()
            };

            return Ok(value);
        }

        [HttpGet("monitor")]
        public async Task<IActionResult> GetMonitorAsync()
        {
            var resourceWatches =
                from resourceWatch in _dbContext.ResourceWatch
                join resource in _dbContext.Resource on resourceWatch.ResourceId equals resource.Id
                join environment in _dbContext.Environment on resourceWatch.EnvironmentId equals environment.Id
                select new
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

            var list = await resourceWatches.ToListAsync();

            return Ok(list);
        }
    }
}
