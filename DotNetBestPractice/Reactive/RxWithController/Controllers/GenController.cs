using Microsoft.AspNetCore.Mvc;
using RxWithController.Models;
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
            var r = GetGenerateMessage();
            
            return new OkObjectResult(r);
        }

        private IObservable<GenerateMessage> GetGenerateMessage()
        {
            var result = Observable.Create<GenerateMessage>(o => Observable.ToAsync(TestMethod)().Subscribe(o));

            return result;
        }

        private GenerateMessage TestMethod()
        {
            //await Task.CompletedTask;
            return new GenerateMessage(Guid.NewGuid().ToString());
        }
    }
}
