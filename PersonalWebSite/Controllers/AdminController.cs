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
        [Authorize]
        public IActionResult Users() 
        {
            using (Context db = new Context())
            {
                var user = db.Users.ToList();
                return View(user);
            }
        }
        [Authorize]
        public IActionResult Comments()
        {
            using (Context db = new Context())
            {
                var comment = db.Comments.ToList();
                return View(comment);
            }
        }
        [Authorize]
        public IActionResult DeleteUser(User user)
        {
            using (Context db = new Context())
            {
                var usr = db.Users.Find(user.Id);
                db.Users.Remove(usr);
                db.SaveChanges();
                return RedirectToAction("Users");
            }
        }
        [Authorize]
        public IActionResult DeleteComment(Comment comment)
        {
            using (Context db = new Context())
            {
                var com = db.Comments.Find(comment.Id);
                db.Comments.Remove(com);
                db.SaveChanges();
                return RedirectToAction("Comments");
            }
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Admin admin)
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
