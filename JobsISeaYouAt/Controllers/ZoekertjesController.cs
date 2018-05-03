using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace JobsISeaYouAt.Models
{
    public class ZoekertjesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Zoekertjes
        public ActionResult Index()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Index", "Index", "Home");
            }

            // return View(db.Zoekertjes.Where(x => x.Aanbieder == db.Users.FirstOrDefault(y => y.Id == User.Identity.GetUserId())));
            return View(db.Zoekertjes.Find());
        }

        // GET: Zoekertjes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zoekertje zoekertje = db.Zoekertjes.Find(id);
            if (zoekertje == null)
            {
                return HttpNotFound();
            }
            return View(zoekertje);
        }

        // GET: Zoekertjes/Create
        public ActionResult Create()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // POST: Zoekertjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titel,FunctieTitel,Datum,Beschrijving")] Zoekertje zoekertje)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Index");
            }

            zoekertje.Datum = DateTime.Now;
            // zoekertjes.Aanbieder = User.Identity;

            if (ModelState.IsValid)
            {
                db.Zoekertjes.Add(zoekertje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zoekertje);
        }

        // GET: Zoekertjes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Index");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zoekertje zoekertje = db.Zoekertjes.Find(id);
            if (zoekertje == null)
            {
                return HttpNotFound();
            }
            return View(zoekertje);
        }

        // POST: Zoekertjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titel,FunctieTitel,Datum,Beschrijving")] Zoekertje zoekertje)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                db.Entry(zoekertje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zoekertje);
        }

        // GET: Zoekertjes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Index");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zoekertje zoekertje = db.Zoekertjes.Find(id);
            if (zoekertje == null)
            {
                return HttpNotFound();
            }

            return View(zoekertje);
        }

        // POST: Zoekertjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Index");
            }

            Zoekertje zoekertje = db.Zoekertjes.Find(id);

            db.Zoekertjes.Remove(zoekertje);
            db.SaveChanges();
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

        protected Boolean IsLoggedIn()
        {
            return System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}
