using Microsoft.AspNetCore.Mvc;

namespace TheWatcher.API.Panel.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }

        [HttpGet("catalog")]
        public IActionResult GetCatalog()
        {
            return Ok();
        }
    }
}
