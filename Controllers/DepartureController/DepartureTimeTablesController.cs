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
    public class DepartureTimeTablesController : Controller
    {
        private DepartureDB1 db = new DepartureDB1();

        // GET: DepartureTimeTables
        public ActionResult Index()
        {
            var departureTimeTables = db.DepartureTimeTables.Include(d => d.Airlines_Departure).Include(d => d.Cities_Departure).Include(d => d.Status_Departure).Include(d => d.Terminal_Departure);
            return View(departureTimeTables.ToList());
        }

        // GET: DepartureTimeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartureTimeTable departureTimeTable = db.DepartureTimeTables.Find(id);
            if (departureTimeTable == null)
            {
                return HttpNotFound();
            }
            return View(departureTimeTable);
        }

        // GET: DepartureTimeTables/Create
        public ActionResult Create()
        {
            ViewBag.AirID = new SelectList(db.Airlines_Departure, "AirID", "Airline");
            ViewBag.CityID = new SelectList(db.Cities_Departure, "CityID", "City");
            ViewBag.StatusID = new SelectList(db.Status_Departure, "StatusID", "Status");
            ViewBag.TerminalID = new SelectList(db.Terminal_Departure, "TerminalID", "Terminals");
            return View();
        }

        // POST: DepartureTimeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AirID,FlightNo,CityID,StatusID,BoradingTime,TerminalID")] DepartureTimeTable departureTimeTable)
        {
            if (ModelState.IsValid)
            {
                db.DepartureTimeTables.Add(departureTimeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AirID = new SelectList(db.Airlines_Departure, "AirID", "Airline", departureTimeTable.AirID);
            ViewBag.CityID = new SelectList(db.Cities_Departure, "CityID", "City", departureTimeTable.CityID);
            ViewBag.StatusID = new SelectList(db.Status_Departure, "StatusID", "Status", departureTimeTable.StatusID);
            ViewBag.TerminalID = new SelectList(db.Terminal_Departure, "TerminalID", "Terminals", departureTimeTable.TerminalID);
            return View(departureTimeTable);
        }

        // GET: DepartureTimeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartureTimeTable departureTimeTable = db.DepartureTimeTables.Find(id);
            if (departureTimeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.AirID = new SelectList(db.Airlines_Departure, "AirID", "Airline", departureTimeTable.AirID);
            ViewBag.CityID = new SelectList(db.Cities_Departure, "CityID", "City", departureTimeTable.CityID);
            ViewBag.StatusID = new SelectList(db.Status_Departure, "StatusID", "Status", departureTimeTable.StatusID);
            ViewBag.TerminalID = new SelectList(db.Terminal_Departure, "TerminalID", "Terminals", departureTimeTable.TerminalID);
            return View(departureTimeTable);
        }

        // POST: DepartureTimeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AirID,FlightNo,CityID,StatusID,BoradingTime,TerminalID")] DepartureTimeTable departureTimeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departureTimeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AirID = new SelectList(db.Airlines_Departure, "AirID", "Airline", departureTimeTable.AirID);
            ViewBag.CityID = new SelectList(db.Cities_Departure, "CityID", "City", departureTimeTable.CityID);
            ViewBag.StatusID = new SelectList(db.Status_Departure, "StatusID", "Status", departureTimeTable.StatusID);
            ViewBag.TerminalID = new SelectList(db.Terminal_Departure, "TerminalID", "Terminals", departureTimeTable.TerminalID);
            return View(departureTimeTable);
        }

        // GET: DepartureTimeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartureTimeTable departureTimeTable = db.DepartureTimeTables.Find(id);
            if (departureTimeTable == null)
            {
                return HttpNotFound();
            }
            return View(departureTimeTable);
        }

        // POST: DepartureTimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartureTimeTable departureTimeTable = db.DepartureTimeTables.Find(id);
            db.DepartureTimeTables.Remove(departureTimeTable);
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
