using Microsoft.AspNetCore.Mvc;
using RxWithController.Services;
using System.Reactive.Linq;

namespace RxWithController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenController : ControllerBase
    {
        private readonly IGenerateService _generateService;

        public GenController(IGenerateService generateService)
        {
            _generateService = generateService;
        }

        [HttpGet("Name")]
        public IActionResult CreateName()
        {
            var name = _generateService.Name().ToObservable();

            return new OkObjectResult(name);
        }
    }
}
