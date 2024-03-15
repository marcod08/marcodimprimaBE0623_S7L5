using Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizzeria.Controllers
{
    public class CartController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Auth");
            }

            int userId = Convert.ToInt32(User.Identity.Name);

            Ordinazione ordine = db.Ordinazione.Include("Dettaglio").FirstOrDefault(o => o.UserId == userId);

            if (ordine != null)
            {
                return View(ordine.Dettaglio.ToList());
            }
            else
            {
                return View();
            }
        }

        
        public ActionResult Add(int Id)
        {
            int userId = Convert.ToInt32(User.Identity.Name);

            Articolo articolo = db.Articolo.Find(Id);

            if (articolo != null)
            {
                Ordinazione ordine = db.Ordinazione.FirstOrDefault(o => o.UserId == userId);

                if (ordine == null)
                {
                    ordine = new Ordinazione
                    {
                        UserId = userId,
                        Indirizzo = "  ", //metto campi vuoti perchè sono obbligatori, li modificherò prima del checkout
                        Note = "  ", 
                        Totale = 0, 
                        Evaso = false 
                    };
                    db.Ordinazione.Add(ordine);
                }

                Dettaglio dettaglio = new Dettaglio
                {
                    Ordinazione = ordine,
                    Articolo = articolo,
                    Quantità = 1
                };
                db.Dettaglio.Add(dettaglio);

                ordine.Totale += articolo.Prezzo;

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Cart"); 
        }

    }

}
