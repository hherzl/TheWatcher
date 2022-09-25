using Microsoft.AspNetCore.Mvc;

namespace TheWatcher.API.Monitor.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class MonitorController : ControllerBase
    {
        private readonly ILogger<MonitorController> _logger;

        public MonitorController(ILogger<MonitorController> logger)
        {
            _logger = logger;
        }
    }
}
