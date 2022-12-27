using Microsoft.AspNetCore.Mvc;
using PersonalWebSite.Models;
using System.Diagnostics;

namespace PersonalWebSite.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

		public IActionResult Detail()
		{
			return View();
		}

		public IActionResult Resume()
		{
			return View();
		}

		public IActionResult HomeTown()
		{
			return View();
		}

		public IActionResult ContactMe()
        {
			return View();
		}

		public IActionResult Login()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}