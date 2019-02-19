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
    public class Status_ArrivalsController : Controller
    {
        private SFOArrivalsDB db = new SFOArrivalsDB();

        // GET: Status_Arrivals
        public ActionResult Index()
        {
            return View(db.Status_Arrivals.ToList());
        }

        // GET: Status_Arrivals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Arrivals status_Arrivals = db.Status_Arrivals.Find(id);
            if (status_Arrivals == null)
            {
                return HttpNotFound();
            }
            return View(status_Arrivals);
        }

        // GET: Status_Arrivals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Status_Arrivals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusID,Status")] Status_Arrivals status_Arrivals)
        {
            if (ModelState.IsValid)
            {
                db.Status_Arrivals.Add(status_Arrivals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(status_Arrivals);
        }

        // GET: Status_Arrivals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Arrivals status_Arrivals = db.Status_Arrivals.Find(id);
            if (status_Arrivals == null)
            {
                return HttpNotFound();
            }
            return View(status_Arrivals);
        }

        // POST: Status_Arrivals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID,Status")] Status_Arrivals status_Arrivals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(status_Arrivals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(status_Arrivals);
        }

        // GET: Status_Arrivals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Arrivals status_Arrivals = db.Status_Arrivals.Find(id);
            if (status_Arrivals == null)
            {
                return HttpNotFound();
            }
            return View(status_Arrivals);
        }

        // POST: Status_Arrivals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Status_Arrivals status_Arrivals = db.Status_Arrivals.Find(id);
            db.Status_Arrivals.Remove(status_Arrivals);
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
