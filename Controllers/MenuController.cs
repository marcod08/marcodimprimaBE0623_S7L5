using Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Pizzeria.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            var pizze = db.Articolo.ToList();
            return View(pizze);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id, Nome, Foto, Prezzo, TempoConsegna, Ingredienti")] Articolo pizza)
        {
            if (ModelState.IsValid)
            {
                db.Articolo.Add(pizza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pizza);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articolo pizza = db.Articolo.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Nome, Foto, Prezzo, TempoConsegna, Ingredienti")] Articolo pizza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pizza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articolo pizza = db.Articolo.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Articolo pizza = db.Articolo.Find(id);
            db.Articolo.Remove(pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}