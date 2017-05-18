using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Khuluma_Server.Models;

namespace Khuluma_Server.Controllers
{
    [Authorize]
    public class LocationModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LocationModels
        public ActionResult Index()
        {
            return View(db.LocationModels.ToList());
        }

        // GET: LocationModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationModel locationModel = db.LocationModels.Find(id);
            if (locationModel == null)
            {
                return HttpNotFound();
            }
            return View(locationModel);
        }

        // GET: LocationModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HospitalName,Province")] LocationModel locationModel)
        {
            if (ModelState.IsValid)
            {
                db.LocationModels.Add(locationModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locationModel);
        }

        // GET: LocationModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationModel locationModel = db.LocationModels.Find(id);
            if (locationModel == null)
            {
                return HttpNotFound();
            }
            return View(locationModel);
        }

        // POST: LocationModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HospitalName,Province")] LocationModel locationModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locationModel);
        }

        // GET: LocationModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationModel locationModel = db.LocationModels.Find(id);
            if (locationModel == null)
            {
                return HttpNotFound();
            }
            return View(locationModel);
        }

        // POST: LocationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationModel locationModel = db.LocationModels.Find(id);
            db.LocationModels.Remove(locationModel);
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
