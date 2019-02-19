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
    public class Terminal_ArrivalsController : Controller
    {
        private SFOArrivalsDB db = new SFOArrivalsDB();

        // GET: Terminal_Arrivals
        public ActionResult Index()
        {
            return View(db.Terminal_Arrivals.ToList());
        }

        // GET: Terminal_Arrivals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminal_Arrivals terminal_Arrivals = db.Terminal_Arrivals.Find(id);
            if (terminal_Arrivals == null)
            {
                return HttpNotFound();
            }
            return View(terminal_Arrivals);
        }

        // GET: Terminal_Arrivals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Terminal_Arrivals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerminalID,Terminals")] Terminal_Arrivals terminal_Arrivals)
        {
            if (ModelState.IsValid)
            {
                db.Terminal_Arrivals.Add(terminal_Arrivals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(terminal_Arrivals);
        }

        // GET: Terminal_Arrivals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminal_Arrivals terminal_Arrivals = db.Terminal_Arrivals.Find(id);
            if (terminal_Arrivals == null)
            {
                return HttpNotFound();
            }
            return View(terminal_Arrivals);
        }

        // POST: Terminal_Arrivals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TerminalID,Terminals")] Terminal_Arrivals terminal_Arrivals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terminal_Arrivals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(terminal_Arrivals);
        }

        // GET: Terminal_Arrivals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminal_Arrivals terminal_Arrivals = db.Terminal_Arrivals.Find(id);
            if (terminal_Arrivals == null)
            {
                return HttpNotFound();
            }
            return View(terminal_Arrivals);
        }

        // POST: Terminal_Arrivals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Terminal_Arrivals terminal_Arrivals = db.Terminal_Arrivals.Find(id);
            db.Terminal_Arrivals.Remove(terminal_Arrivals);
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
