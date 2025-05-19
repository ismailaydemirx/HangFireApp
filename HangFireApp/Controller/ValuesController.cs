using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangFireApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            BackgroundJob.Enqueue(() => BackgroundTestServices.HangFireWorks());
            return Ok("Hangfire worked.");
        }
    }

    public class BackgroundTestServices
    {
        // also we can make this function async.
        public static void HangFireWorks()
        {
            Console.WriteLine($"Hangfire is working: {DateTime.UtcNow}");
        }
    }
}
