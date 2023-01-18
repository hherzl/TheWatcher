using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWatcher.API.Common.Models;
using TheWatcher.API.Common.Models.Contracts;
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
        [ProducesResponseType(200, Type = typeof(IListResponse<WatcherItemModel>))]
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
        [ProducesResponseType(200, Type = typeof(SingleResponse<WatcherDetailsModel>))]
        public async Task<IActionResult> GetWatcherAsync(short? id)
        {
            var entity = await _dbContext
                .Watcher
                .Include(e => e.WatcherParameterList)
                .FirstOrDefaultAsync(item => item.Id == id)
                ;

            if (entity == null)
                return NotFound();

            var response = new SingleResponse<WatcherDetailsModel>
            {
                Model = new()
                {
                    Id = entity.Id,
                    Guid = entity.Guid,
                    AssemblyQualifiedName = entity.AssemblyQualifiedName,
                    Name = entity.Name,
                    Description = entity.Description,
                    Parameters = entity.WatcherParameterList.Select(item => new WatcherParameterDetailsModel(item.Id, item.IsDefault, item.Parameter, item.Value, item.Description)).ToList()
                }
            };

            return response.ToOkResult();
        }

        [HttpGet("resource")]
        [ProducesResponseType(200, Type = typeof(IListResponse<ResourceItemModel>))]
        public async Task<IActionResult> GetResourcesAsync()
        {
            var response = new ListResponse<ResourceItemModel>();

            var resources =
                from resource in _dbContext.Resource
                join category in _dbContext.ResourceCategory on resource.ResourceCategoryId equals category.Id
                select new ResourceItemModel
                {
                    Id = resource.Id,
                    Name = resource.Name,
                    ResourceCategoryId = resource.ResourceCategoryId,
                    ResourceCategory = category.Name
                };

            response.Model = await resources.ToListAsync();

            return response.ToOkResult();
        }

        [HttpGet("resource/{id}")]
        [ProducesResponseType(200, Type = typeof(SingleResponse<ResourceDetailsModel>))]
        public async Task<IActionResult> GetResourceAsync(short? id)
        {
            var entity = await _dbContext
                .Resource
                .Include(e => e.ResourceCategoryFk.WatcherFk)
                .Include(e => e.ResourceWatchList)
                    .ThenInclude(e => e.EnvironmentFk)
                .Include(e => e.ResourceWatchList)
                    .ThenInclude(e => e.ResourceWatchParameterList)
                .FirstOrDefaultAsync(item => item.Id == id)
                ;

            if (entity == null)
                return NotFound();

            var response = new SingleResponse<ResourceDetailsModel>
            {
                Model = new()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    ResourceCategoryId = entity.ResourceCategoryId,
                    ResourceCategory = entity.ResourceCategoryFk.Name,
                    WatcherId = entity.ResourceCategoryFk.WatcherId,
                    Watcher = entity.ResourceCategoryFk.WatcherFk.Name,
                    Watches = entity.ResourceWatchList.Select(watch => new ResourceWatchDetailsModel
                    {
                        Id = watch.Id,
                        EnvironmentId = watch.EnvironmentId,
                        Environment = watch.EnvironmentFk.Name,
                        Successful = watch.Successful,
                        WatchCount = watch.WatchCount,
                        LastWatch = watch.LastWatch,
                        Interval = watch.Interval,
                        Parameters = watch
                            .ResourceWatchParameterList
                            .Select(parameter => new ResourceWatchParameterDetailsModel
                            {
                                Parameter = parameter.Parameter,
                                Value = parameter.Value,
                                Description = parameter.Description
                            })
                            .ToList()
                    }).ToList()
                }
            };

            return response.ToOkResult();
        }
    }
}
