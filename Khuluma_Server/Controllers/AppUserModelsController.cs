using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Khuluma_Server.Models;
using Khuluma_Server.Models.ViewModels;

namespace Khuluma_Server.Controllers
{
    [Authorize]
    public class AppUserModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private List<AppUserModel> appUsers = new List<AppUserModel>();
        //public IEnumerable<UserViewModel> userList;

        // GET: AppUserModels
        public ActionResult Index()
        {
            
           

            var userList = from u in new ApplicationDbContext().AppUserModels
                        select new UserViewModel
                        {
                            ID = u.ID,
                            Username = u.Username,
                            Name = u.Name,
                            Surname = u.Surname,
                            ParticipantId = u.ParticipantId,
                            LocationName = u.Location.HospitalName,
                            GroupName = u.Group.GroupName
                        };
            
            return View(userList.ToList());

        }

        // GET: AppUserModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUserModel appUserModel = db.AppUserModels.Find(id);
            if (appUserModel == null)
            {
                return HttpNotFound();
            }
            return View(appUserModel);
        }

        // GET: AppUserModels/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.GroupModels, "ID", "GroupName");
            ViewBag.LocationId = new SelectList(db.LocationModels, "ID", "HospitalName");
            return View();
        }

        // POST: AppUserModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,Name,Surname,Age,PhoneNumber,Email,HomeAddress,ParticipantId,LocationId,GroupId")] AppUserModel appUserModel)
        {
            if (ModelState.IsValid)
            {
                db.AppUserModels.Add(appUserModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.GroupModels, "ID", "GroupName", appUserModel.GroupId);
            ViewBag.LocationId = new SelectList(db.LocationModels, "ID", "HospitalName", appUserModel.LocationId);
            return View(appUserModel);
        }

        // GET: AppUserModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUserModel appUserModel = db.AppUserModels.Find(id);
            if (appUserModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.GroupModels, "ID", "GroupName", appUserModel.GroupId);
            ViewBag.LocationId = new SelectList(db.LocationModels, "ID", "HospitalName", appUserModel.LocationId);
            return View(appUserModel);
        }

        // POST: AppUserModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,Name,Surname,Age,PhoneNumber,Email,HomeAddress,ParticipantId,LocationId,GroupId")] AppUserModel appUserModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appUserModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.GroupModels, "ID", "GroupName", appUserModel.GroupId);
            ViewBag.LocationId = new SelectList(db.LocationModels, "ID", "HospitalName", appUserModel.LocationId);
            return View(appUserModel);
        }

        // GET: AppUserModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUserModel appUserModel = db.AppUserModels.Find(id);
            if (appUserModel == null)
            {
                return HttpNotFound();
            }
            return View(appUserModel);
        }

        // POST: AppUserModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppUserModel appUserModel = db.AppUserModels.Find(id);
            db.AppUserModels.Remove(appUserModel);
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
