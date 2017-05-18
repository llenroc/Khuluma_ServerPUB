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
    public class FlaggedContentModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FlaggedContentModels
        public ActionResult Index()
        {
            return View(db.FlaggedContentModels.ToList());
        }

        // GET: FlaggedContentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlaggedContentModel flaggedContentModel = db.FlaggedContentModels.Find(id);
            if (flaggedContentModel == null)
            {
                return HttpNotFound();
            }
            return View(flaggedContentModel);
        }

        // GET: FlaggedContentModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlaggedContentModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ContentText")] FlaggedContentModel flaggedContentModel)
        {
            if (ModelState.IsValid)
            {
                db.FlaggedContentModels.Add(flaggedContentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flaggedContentModel);
        }

        // GET: FlaggedContentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlaggedContentModel flaggedContentModel = db.FlaggedContentModels.Find(id);
            if (flaggedContentModel == null)
            {
                return HttpNotFound();
            }
            return View(flaggedContentModel);
        }

        // POST: FlaggedContentModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ContentText")] FlaggedContentModel flaggedContentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flaggedContentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flaggedContentModel);
        }

        // GET: FlaggedContentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlaggedContentModel flaggedContentModel = db.FlaggedContentModels.Find(id);
            if (flaggedContentModel == null)
            {
                return HttpNotFound();
            }
            return View(flaggedContentModel);
        }

        // POST: FlaggedContentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlaggedContentModel flaggedContentModel = db.FlaggedContentModels.Find(id);
            db.FlaggedContentModels.Remove(flaggedContentModel);
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
