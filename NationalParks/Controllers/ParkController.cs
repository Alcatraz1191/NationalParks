using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NationalParks.APIHandlerManager;
using NationalParks.Models;
using NationalParks.Repository;

namespace NationalParks.Controllers
{
    public class ParkController : Controller
    {
        // GET: Park
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ParksModel()
        {
            APIHandler webHandler = new APIHandler();
            ParksModel parks = webHandler.GetParks();
            ParkRepo parkRepo = new ParkRepo();

            return View(parks);
        }

        // GET: Parks/Details/5
        public ActionResult GetAllParkDetails()
        {
            ParkRepo parkRepo = new ParkRepo();
            ModelState.Clear();
            
            return View(parkRepo.GetAllParks());
        }
    }
}
