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
    public class Terminal_DepartureController : Controller
    {
        private DepartureDB1 db = new DepartureDB1();

        // GET: Terminal_Departure
        public ActionResult Index()
        {
            return View(db.Terminal_Departure.ToList());
        }

        // GET: Terminal_Departure/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminal_Departure terminal_Departure = db.Terminal_Departure.Find(id);
            if (terminal_Departure == null)
            {
                return HttpNotFound();
            }
            return View(terminal_Departure);
        }

        // GET: Terminal_Departure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Terminal_Departure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerminalID,Terminals")] Terminal_Departure terminal_Departure)
        {
            if (ModelState.IsValid)
            {
                db.Terminal_Departure.Add(terminal_Departure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(terminal_Departure);
        }

        // GET: Terminal_Departure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminal_Departure terminal_Departure = db.Terminal_Departure.Find(id);
            if (terminal_Departure == null)
            {
                return HttpNotFound();
            }
            return View(terminal_Departure);
        }

        // POST: Terminal_Departure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TerminalID,Terminals")] Terminal_Departure terminal_Departure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terminal_Departure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(terminal_Departure);
        }

        // GET: Terminal_Departure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminal_Departure terminal_Departure = db.Terminal_Departure.Find(id);
            if (terminal_Departure == null)
            {
                return HttpNotFound();
            }
            return View(terminal_Departure);
        }

        // POST: Terminal_Departure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Terminal_Departure terminal_Departure = db.Terminal_Departure.Find(id);
            db.Terminal_Departure.Remove(terminal_Departure);
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
