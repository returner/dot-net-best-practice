using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HealthController : ControllerBase
    {
        [HttpGet("health")]
        public IActionResult GetHealthStatus()
        {
            return Ok();
        }
    }
}
