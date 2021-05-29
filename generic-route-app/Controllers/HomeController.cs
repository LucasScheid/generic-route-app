using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace generic_route_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["APP_NAME"] = Environment.GetEnvironmentVariable("APP_NAME");
            ViewData["MACHINE_NAME"] = Environment.MachineName;
            ViewData["OS_VERSION"] = Environment.OSVersion;
            ViewData["REQUEST_HOST"] = this.Request.Host.Value;
            ViewData["REQUEST_PATH"] = this.Request.Path;

            return View();
        }
    }
}
