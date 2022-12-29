using Microsoft.AspNetCore.Http;
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
		public IActionResult Login2()
		{
			return View();
		}
        [HttpPost]
		public IActionResult Login2(User user)
		{
			using (Context db = new Context())
			{
				var usr = db.Users.Single(u => u.Email == user.Email && u.Password == user.Password);
                if(usr != null)
                {
                    HttpContext.Session.SetString("Id", usr.Id.ToString());
					HttpContext.Session.SetString("Name", usr.Name.ToString());
					HttpContext.Session.SetString("Surname", usr.Surname.ToString());
					HttpContext.Session.SetString("Title", usr.Title.ToString());
                    return RedirectToAction("Index");
				}
                else
                {
                    ModelState.AddModelError("", "E-mail or Password is wrong.");
                }
			}
			return View();
		}
		public IActionResult Register2()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Register2(User user)
		{
			if (ModelState.IsValid)
            {
                using (Context db = new Context())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            return View();
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}