using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                    CategoryId = resource.ResourceCategoryId,
                    Category = category.Name
                };

            var list = await resources.ToListAsync();

            return Ok(list);
        }
    }
}
