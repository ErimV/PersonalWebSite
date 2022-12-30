using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalWebSite.Models;
using System.Security.Claims;

namespace PersonalWebSite.Controllers
{
	public class AdminController : Controller
	{

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login2(Admin admin)
        {
            using (Context db = new Context())
            {
                var adm = db.Admins.SingleOrDefault(a => a.Email == admin.Email && a.Password == admin.Password);
                if (adm != null)
                {
                    //Create the identity for the user  
                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, adm.Email)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "E-mail or Password is wrong.");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
