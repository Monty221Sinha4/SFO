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
    public class ArrivalTimeTablesController : Controller
    {
        private ArrivalDB1 db = new ArrivalDB1();

        // GET: ArrivalTimeTables
        public ActionResult Index()
        {
            var arrivalTimeTables = db.ArrivalTimeTables.Include(a => a.Airlines_Arrivals).Include(a => a.Cities_Arrivals).Include(a => a.Status_Arrivals).Include(a => a.Terminal_Arrivals);
            return View(arrivalTimeTables.ToList());
        }

        // GET: ArrivalTimeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArrivalTimeTable arrivalTimeTable = db.ArrivalTimeTables.Find(id);
            if (arrivalTimeTable == null)
            {
                return HttpNotFound();
            }
            return View(arrivalTimeTable);
        }

        // GET: ArrivalTimeTables/Create
        public ActionResult Create()
        {
            ViewBag.AirID = new SelectList(db.Airlines_Arrivals, "AirID", "Airline");
            ViewBag.CityID = new SelectList(db.Cities_Arrivals, "CityID", "City");
            ViewBag.StatusID = new SelectList(db.Status_Arrivals, "StatusID", "Status");
            ViewBag.TerminalID = new SelectList(db.Terminal_Arrivals, "TerminalID", "Terminals");
            return View();
        }

        // POST: ArrivalTimeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AirID,FlightNo,CityID,StatusID,ArrivalTime,TerminalID")] ArrivalTimeTable arrivalTimeTable)
        {
            if (ModelState.IsValid)
            {
                db.ArrivalTimeTables.Add(arrivalTimeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AirID = new SelectList(db.Airlines_Arrivals, "AirID", "Airline", arrivalTimeTable.AirID);
            ViewBag.CityID = new SelectList(db.Cities_Arrivals, "CityID", "City", arrivalTimeTable.CityID);
            ViewBag.StatusID = new SelectList(db.Status_Arrivals, "StatusID", "Status", arrivalTimeTable.StatusID);
            ViewBag.TerminalID = new SelectList(db.Terminal_Arrivals, "TerminalID", "Terminals", arrivalTimeTable.TerminalID);
            return View(arrivalTimeTable);
        }

        // GET: ArrivalTimeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArrivalTimeTable arrivalTimeTable = db.ArrivalTimeTables.Find(id);
            if (arrivalTimeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.AirID = new SelectList(db.Airlines_Arrivals, "AirID", "Airline", arrivalTimeTable.AirID);
            ViewBag.CityID = new SelectList(db.Cities_Arrivals, "CityID", "City", arrivalTimeTable.CityID);
            ViewBag.StatusID = new SelectList(db.Status_Arrivals, "StatusID", "Status", arrivalTimeTable.StatusID);
            ViewBag.TerminalID = new SelectList(db.Terminal_Arrivals, "TerminalID", "Terminals", arrivalTimeTable.TerminalID);
            return View(arrivalTimeTable);
        }

        // POST: ArrivalTimeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AirID,FlightNo,CityID,StatusID,ArrivalTime,TerminalID")] ArrivalTimeTable arrivalTimeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arrivalTimeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AirID = new SelectList(db.Airlines_Arrivals, "AirID", "Airline", arrivalTimeTable.AirID);
            ViewBag.CityID = new SelectList(db.Cities_Arrivals, "CityID", "City", arrivalTimeTable.CityID);
            ViewBag.StatusID = new SelectList(db.Status_Arrivals, "StatusID", "Status", arrivalTimeTable.StatusID);
            ViewBag.TerminalID = new SelectList(db.Terminal_Arrivals, "TerminalID", "Terminals", arrivalTimeTable.TerminalID);
            return View(arrivalTimeTable);
        }

        // GET: ArrivalTimeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArrivalTimeTable arrivalTimeTable = db.ArrivalTimeTables.Find(id);
            if (arrivalTimeTable == null)
            {
                return HttpNotFound();
            }
            return View(arrivalTimeTable);
        }

        // POST: ArrivalTimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArrivalTimeTable arrivalTimeTable = db.ArrivalTimeTables.Find(id);
            db.ArrivalTimeTables.Remove(arrivalTimeTable);
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
