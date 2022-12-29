using Microsoft.AspNetCore.Mvc;

namespace PersonalWebSite.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
