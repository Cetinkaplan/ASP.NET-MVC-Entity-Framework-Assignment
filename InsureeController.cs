
using System;
using System.Linq;
using System.Web.Mvc;
using YourProjectName.Models;

namespace YourProjectName.Controllers
{
    public class InsureeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,SpeedingTickets,DUI,FullCoverage")]
            Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                // Start with a base quote of $50 per month.
                decimal quote = 50m;

                // Calculate the customer's age.
                int age = DateTime.Now.Year - insuree.DateOfBirth.Year;

                if (insuree.DateOfBirth > DateTime.Now.AddYears(-age))
                {
                    age--;
                }

                // Age-based pricing.
                if (age <= 18)
                {
                    quote += 100m;
                }
                else if (age >= 19 && age <= 25)
                {
                    quote += 50m;
                }
                else
                {
                    quote += 25m;
                }

                // Car year pricing.
                if (insuree.CarYear < 2000)
                {
                    quote += 25m;
                }

                if (insuree.CarYear > 2015)
                {
                    quote += 25m;
                }

                // Porsche pricing.
                if (!string.IsNullOrEmpty(insuree.CarMake) &&
                    insuree.CarMake.Equals("Porsche", StringComparison.OrdinalIgnoreCase))
                {
                    quote += 25m;

                    // Additional charge for Porsche 911 Carrera.
                    if (!string.IsNullOrEmpty(insuree.CarModel) &&
                        insuree.CarModel.Equals("911 Carrera", StringComparison.OrdinalIgnoreCase))
                    {
                        quote += 25m;
                    }
                }

                // Add $10 for every speeding ticket.
                quote += insuree.SpeedingTickets * 10m;

                // Add 25% if the customer has ever had a DUI.
                if (insuree.DUI)
                {
                    quote += quote * 0.25m;
                }

                // Add 50% for full coverage.
                if (insuree.FullCoverage)
                {
                    quote += quote * 0.50m;
                }

                // Store the calculated quote.
                insuree.Quote = quote;

                // Save the customer and quote to the database.
                db.Insurees.Add(insuree);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Admin
        public ActionResult Admin()
        {
            var insurees = db.Insurees.ToList();

            return View(insurees);
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    System.Net.HttpStatusCode.BadRequest);
            }

            Insuree insuree = db.Insurees.Find(id);

            if (insuree == null)
            {
                return HttpNotFound();
            }

            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    System.Net.HttpStatusCode.BadRequest);
            }

            Insuree insuree = db.Insurees.Find(id);

            if (insuree == null)
            {
                return HttpNotFound();
            }

            return View(insuree);
        }

        // POST: Insuree/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State =
                    System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    System.Net.HttpStatusCode.BadRequest);
            }

            Insuree insuree = db.Insurees.Find(id);

            if (insuree == null)
            {
                return HttpNotFound();
            }

            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);

            if (insuree != null)
            {
                db.Insurees.Remove(insuree);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}

