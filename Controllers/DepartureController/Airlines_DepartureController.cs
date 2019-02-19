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
    public class Airlines_DepartureController : Controller
    {
        private DepartureDB1 db = new DepartureDB1();

        // GET: Airlines_Departure
        public ActionResult Index()
        {
            return View(db.Airlines_Departure.ToList());
        }

        // GET: Airlines_Departure/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airlines_Departure airlines_Departure = db.Airlines_Departure.Find(id);
            if (airlines_Departure == null)
            {
                return HttpNotFound();
            }
            return View(airlines_Departure);
        }

        // GET: Airlines_Departure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Airlines_Departure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AirID,Airline")] Airlines_Departure airlines_Departure)
        {
            if (ModelState.IsValid)
            {
                db.Airlines_Departure.Add(airlines_Departure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airlines_Departure);
        }

        // GET: Airlines_Departure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airlines_Departure airlines_Departure = db.Airlines_Departure.Find(id);
            if (airlines_Departure == null)
            {
                return HttpNotFound();
            }
            return View(airlines_Departure);
        }

        // POST: Airlines_Departure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AirID,Airline")] Airlines_Departure airlines_Departure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airlines_Departure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airlines_Departure);
        }

        // GET: Airlines_Departure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airlines_Departure airlines_Departure = db.Airlines_Departure.Find(id);
            if (airlines_Departure == null)
            {
                return HttpNotFound();
            }
            return View(airlines_Departure);
        }

        // POST: Airlines_Departure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Airlines_Departure airlines_Departure = db.Airlines_Departure.Find(id);
            db.Airlines_Departure.Remove(airlines_Departure);
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
