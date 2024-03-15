using Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizzeria.Controllers
{
    public class UsersController : Controller
    {
        DBContext db = new DBContext();

        // GET: Users
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var user = User;
            var users = db.User.ToList();
            return View(users);
        }
    }
}