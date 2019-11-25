using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NationalParks.DAL;
using NationalParks.Models;

namespace NationalParks.Controllers
{
    public class ParksController : Controller
    {
        private ParkContext db = new ParkContext();

        // GET: Parks
        public ActionResult Index()
        { 
            return View(db.Parks.ToList());
        }

        // GET: Parks/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Park park = db.Parks.Find(id);
            if (park == null)
            {
                return HttpNotFound();
            }
            return View(park);
        }

        public ActionResult Visitors(string parkCode)
        {
            var visitors = from v in db.Visitors
                           where v.parkCode == parkCode
                           select v;

            return View(visitors.ToList());
        }

        // GET: Parks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CampgroundsID,VisitorsID,states,latLong,description,designation,parkCode,directionsInfo,directionsUrl,fullName,url,weatherInfo,name")] Park park)
        {
            if (ModelState.IsValid)
            {
                db.Parks.Add(park);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(park);
        }

        // GET: Parks/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Park park = db.Parks.Find(id);
            if (park == null)
            {
                return HttpNotFound();
            }
            return View(park);
        }

        // POST: Parks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CampgroundsID,VisitorsID,states,latLong,description,designation,parkCode,directionsInfo,directionsUrl,fullName,url,weatherInfo,name")] Park park)
        {
            if (ModelState.IsValid)
            {
                db.Entry(park).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(park);
        }

        // GET: Parks/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Park park = db.Parks.Find(id);
            if (park == null)
            {
                return HttpNotFound();
            }
            return View(park);
        }

        // POST: Parks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Park park = db.Parks.Find(id);
            db.Parks.Remove(park);
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
        ActionResult About()
        {
            return View();
        }
    }
}
