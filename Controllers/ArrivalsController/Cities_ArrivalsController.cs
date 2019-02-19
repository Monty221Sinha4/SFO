using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SFOProject;

namespace SFOProject.Controllers.ArrivalsController
{
    public class Cities_ArrivalsController : Controller
    {
        private SFOArrivalsDB db = new SFOArrivalsDB();

        // GET: Cities_Arrivals
        public ActionResult Index()
        {
            return View(db.Cities_Arrivals.ToList());
        }

        // GET: Cities_Arrivals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities_Arrivals cities_Arrivals = db.Cities_Arrivals.Find(id);
            if (cities_Arrivals == null)
            {
                return HttpNotFound();
            }
            return View(cities_Arrivals);
        }

        // GET: Cities_Arrivals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cities_Arrivals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityID,City")] Cities_Arrivals cities_Arrivals)
        {
            if (ModelState.IsValid)
            {
                db.Cities_Arrivals.Add(cities_Arrivals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cities_Arrivals);
        }

        // GET: Cities_Arrivals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities_Arrivals cities_Arrivals = db.Cities_Arrivals.Find(id);
            if (cities_Arrivals == null)
            {
                return HttpNotFound();
            }
            return View(cities_Arrivals);
        }

        // POST: Cities_Arrivals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityID,City")] Cities_Arrivals cities_Arrivals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cities_Arrivals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cities_Arrivals);
        }

        // GET: Cities_Arrivals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities_Arrivals cities_Arrivals = db.Cities_Arrivals.Find(id);
            if (cities_Arrivals == null)
            {
                return HttpNotFound();
            }
            return View(cities_Arrivals);
        }

        // POST: Cities_Arrivals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cities_Arrivals cities_Arrivals = db.Cities_Arrivals.Find(id);
            db.Cities_Arrivals.Remove(cities_Arrivals);
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
