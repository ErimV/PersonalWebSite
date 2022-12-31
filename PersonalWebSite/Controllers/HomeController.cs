using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using PersonalWebSite.Models;
using PersonalWebSite.Resources.Languages;
using System.Diagnostics;

namespace PersonalWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<Lang> _stringLocalizer;
        private readonly IHtmlLocalizer<Lang> _htmlLocalizer;

        public HomeController(IStringLocalizer<Lang> stringLocalizer)
        => _stringLocalizer = stringLocalizer;


        public IActionResult Index()
        {
            ViewBag.PageIndex = _stringLocalizer["page.Index"];
            return View();
        }

        public IActionResult Privacy()
        {
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
            return View();
        }
        [HttpPost]
        public IActionResult LeaveComment(Comment com)
        {
			using (Context db = new Context())
            {
				Comment comment = new Comment();
                comment.Text = com.Text;
				comment.UserName = HttpContext.Session.GetString("Name");
				comment.UserSurname = HttpContext.Session.GetString("Surname");
				comment.UserTitle = HttpContext.Session.GetString("Title");
				comment.TimeStamp = DateTime.Now;
				db.Comments.Add(comment);
				db.SaveChanges();
                return RedirectToAction("Comments");
            }
		}
        public IActionResult ContactMe()
        {
            ViewBag.PageContactMe = _stringLocalizer["page.ContactMe"];
            return View();
		}
		public IActionResult Login2()
		{
            ViewBag.PageLogin = _stringLocalizer["page.Login"];
            return View();
		}
        [HttpPost]
		public IActionResult Login2(User user)
		{
            ViewBag.PageLogin = _stringLocalizer["page.Login"];
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