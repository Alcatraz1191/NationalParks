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
            APIHandler webHandler = new APIHandler();
            ParksModel parks = webHandler.GetParks();
            ParkRepo parkRepo = new ParkRepo();

            foreach (Parks item in parks.data)
            {
                parkRepo.AddPark(item);
            }
            return View();
        }

        public ActionResult ParksModel()
        {
            ParkRepo parkRepo = new ParkRepo();
            ParksModel parks = new ParksModel();
            parks.data = parkRepo.GetAllParks();
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
