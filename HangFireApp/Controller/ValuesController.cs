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
            BackgroundJob.Enqueue(() => BackgroundServives.HangFireWorks());
            return Ok("Hangfire worked.");
        }
    }

    public class BackgroundServives
    {
        public static void HangFireWorks()
        {
            Console.WriteLine($"Hangfire is working: {DateTime.UtcNow}");
        }
    }
}
