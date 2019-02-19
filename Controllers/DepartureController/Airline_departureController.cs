using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SFOProject.Models.Departure;

namespace SFOProject.Controllers.DepartureController
{
    public class Airline_departureController : Controller
    {
        // GET: Airline_departure
        public ActionResult Index()
        {
            return View();
        }
    }
}