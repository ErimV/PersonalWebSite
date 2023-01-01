using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using PersonalWebSite.Models;
using System.Diagnostics;
using System.Globalization;

namespace PersonalWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> stringLocalizer)
        {
            _logger = logger;
            _stringLocalizer = stringLocalizer;
        }


        public IActionResult Index()
        {
            
            var cultureInfo = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            

            ViewBag.PageIndex = _stringLocalizer["page.Index"];
			ViewData["Title"] = _stringLocalizer["page.Login"];
			return View();
        }

		public IActionResult Detail()
		{
            ViewBag.PageDetail = _stringLocalizer["page.Detail"];
            return View();
		}

		public IActionResult Resume()
		{
            ViewBag.PageResume = _stringLocalizer["page.Resume"];
            return View();
		}

		public IActionResult HomeTown()
		{
            ViewBag.PageHomeTown = _stringLocalizer["page.HomeTown"];
            return View();
		}

        public IActionResult Comments()
        {
            ViewBag.PageComments = _stringLocalizer["page.Comments"];
            using (Context db = new Context())
            {
                var comment = db.Comments.ToList();
                return View(comment);
            }
        }
        public IActionResult LeaveComment()
        {
            ViewBag.PageLogin = _stringLocalizer["page.Login"];
			if (HttpContext.Session.GetString("Email") != null)
			{
				return View();
			}
			else
            {
                return RedirectToAction("Login");
            }
            
        }
        [HttpPost]
        public IActionResult LeaveComment(Comment com)
        {
            if(com.Text != null)
            {
                using (Context db = new Context())
                {
				    com.UserName = HttpContext.Session.GetString("Name");
				    com.UserSurname = HttpContext.Session.GetString("Surname");
				    com.UserTitle = HttpContext.Session.GetString("Title");
				    com.TimeStamp = DateTime.Now;
				    db.Comments.Add(com);
				    db.SaveChanges();
                    return RedirectToAction("Comments");
                }
            }
			return View();

		}
        public IActionResult ContactMe()
        {
            ViewBag.PageContactMe = _stringLocalizer["page.ContactMe"];
            return View();
		}
		public IActionResult Login()
		{
            ViewBag.PageLogin = _stringLocalizer["page.Login"];

			return View();
		}
        [HttpPost]
		public IActionResult Login(User user)
		{
            ViewBag.PageLogin = _stringLocalizer["page.Login"];
            using (Context db = new Context())
			{
				var usr = db.Users.SingleOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                if(usr != null)
                {
                    HttpContext.Session.SetString("Id", usr.Id.ToString());
					HttpContext.Session.SetString("Name", usr.Name.ToString());
					HttpContext.Session.SetString("Surname", usr.Surname.ToString());
					HttpContext.Session.SetString("Title", usr.Title.ToString());
					HttpContext.Session.SetString("Email", usr.Email.ToString());
					return RedirectToAction("Index");
				}
                else
                {
                    ModelState.AddModelError("", "E-mail ya da Şifre yanlış.");
                }
			}
			return View();
		}
		public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Register(User user)
		{
			if (ModelState.IsValid)
            {
                using (Context db = new Context())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    HttpContext.Session.SetString("Id", user.Id.ToString());
                    HttpContext.Session.SetString("Name", user.Name.ToString());
                    HttpContext.Session.SetString("Surname", user.Surname.ToString());
                    HttpContext.Session.SetString("Title", user.Title.ToString());
                    return RedirectToAction("Index");
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