using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SFO1;

namespace SFO1.Controllers
{
    public class Cities_DepartureController : Controller
    {
        private DepartureDB1 db = new DepartureDB1();

        // GET: Cities_Departure
        public ActionResult Index()
        {
            return View(db.Cities_Departure.ToList());
        }

        // GET: Cities_Departure/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities_Departure cities_Departure = db.Cities_Departure.Find(id);
            if (cities_Departure == null)
            {
                return HttpNotFound();
            }
            return View(cities_Departure);
        }

        // GET: Cities_Departure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cities_Departure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityID,City")] Cities_Departure cities_Departure)
        {
            if (ModelState.IsValid)
            {
                db.Cities_Departure.Add(cities_Departure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cities_Departure);
        }

        // GET: Cities_Departure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities_Departure cities_Departure = db.Cities_Departure.Find(id);
            if (cities_Departure == null)
            {
                return HttpNotFound();
            }
            return View(cities_Departure);
        }

        // POST: Cities_Departure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityID,City")] Cities_Departure cities_Departure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cities_Departure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cities_Departure);
        }

        // GET: Cities_Departure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities_Departure cities_Departure = db.Cities_Departure.Find(id);
            if (cities_Departure == null)
            {
                return HttpNotFound();
            }
            return View(cities_Departure);
        }

        // POST: Cities_Departure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cities_Departure cities_Departure = db.Cities_Departure.Find(id);
            db.Cities_Departure.Remove(cities_Departure);
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
    }
}
