using Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Pizzeria.Controllers
{
    public class AuthController : Controller
    {
        DBContext db = new DBContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var loggedUser = db.User.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
            if (loggedUser == null)
            {
                TempData["ErrorLogin"] = true;
                return RedirectToAction("Login");
            }

            FormsAuthentication.SetAuthCookie(loggedUser.Id.ToString(), true);
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}