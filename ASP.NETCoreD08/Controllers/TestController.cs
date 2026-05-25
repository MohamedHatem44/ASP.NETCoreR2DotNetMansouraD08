using ASP.NETCoreD08.Helper;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreD08.Controllers
{
    public class TestController : Controller
    {
        private readonly IPrint _print;
        private readonly IConfiguration _configuration;

        // Constructor injection of the IPrint service
        // Ask the container to provide an instance of IPrint when creating TestController
        public TestController(IPrint print, IConfiguration configuration)
        {
            _print = print;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            _print.PrintDateTime();
            return Content("Check the console for the current date and time.");
        }

        public IActionResult TestLifeTime()
        {
            ViewBag.PrintId = _print.Id;
            _print.PrintDateTime();
            return View();
        }

        public IActionResult ReadFromConfiguration()
        {
            var appName = _configuration.GetSection("AppName").Value;
            return Content($"App Name: {appName}");
        }
    }
}
