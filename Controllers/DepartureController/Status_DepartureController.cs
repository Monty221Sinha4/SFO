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
    public class Status_DepartureController : Controller
    {
        private DepartureDB1 db = new DepartureDB1();

        // GET: Status_Departure
        public ActionResult Index()
        {
            return View(db.Status_Departure.ToList());
        }

        // GET: Status_Departure/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Departure status_Departure = db.Status_Departure.Find(id);
            if (status_Departure == null)
            {
                return HttpNotFound();
            }
            return View(status_Departure);
        }

        // GET: Status_Departure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Status_Departure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusID,Status")] Status_Departure status_Departure)
        {
            if (ModelState.IsValid)
            {
                db.Status_Departure.Add(status_Departure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(status_Departure);
        }

        // GET: Status_Departure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Departure status_Departure = db.Status_Departure.Find(id);
            if (status_Departure == null)
            {
                return HttpNotFound();
            }
            return View(status_Departure);
        }

        // POST: Status_Departure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID,Status")] Status_Departure status_Departure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(status_Departure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(status_Departure);
        }

        // GET: Status_Departure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Departure status_Departure = db.Status_Departure.Find(id);
            if (status_Departure == null)
            {
                return HttpNotFound();
            }
            return View(status_Departure);
        }

        // POST: Status_Departure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Status_Departure status_Departure = db.Status_Departure.Find(id);
            db.Status_Departure.Remove(status_Departure);
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
