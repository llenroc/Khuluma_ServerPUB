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
    public class MobilePagesModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MobilePagesModels
        public ActionResult Index()
        {
            return View(db.MobilePagesModels.ToList());
        }

        // GET: MobilePagesModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobilePagesModel mobilePagesModel = db.MobilePagesModels.Find(id);
            if (mobilePagesModel == null)
            {
                return HttpNotFound();
            }
            return View(mobilePagesModel);
        }

        // GET: MobilePagesModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MobilePagesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageId,PageTitle,PageHTMLContent")] MobilePagesModel mobilePagesModel)
        {
            if (ModelState.IsValid)
            {
                db.MobilePagesModels.Add(mobilePagesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mobilePagesModel);
        }

        // GET: MobilePagesModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobilePagesModel mobilePagesModel = db.MobilePagesModels.Find(id);
            if (mobilePagesModel == null)
            {
                return HttpNotFound();
            }
            return View(mobilePagesModel);
        }

        // POST: MobilePagesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageId,PageTitle,PageHTMLContent")] MobilePagesModel mobilePagesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobilePagesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mobilePagesModel);
        }

        // GET: MobilePagesModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobilePagesModel mobilePagesModel = db.MobilePagesModels.Find(id);
            if (mobilePagesModel == null)
            {
                return HttpNotFound();
            }
            return View(mobilePagesModel);
        }

        // POST: MobilePagesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MobilePagesModel mobilePagesModel = db.MobilePagesModels.Find(id);
            db.MobilePagesModels.Remove(mobilePagesModel);
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
