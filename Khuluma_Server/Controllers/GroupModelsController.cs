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
    public class GroupModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private GroupDetailsViewModel groupViewModel;

        // GET: GroupModels
        public ActionResult Index()
        {
            return View(db.GroupModels.ToList());
        }

        // GET: GroupModels/Details/5
        public ActionResult Details(int? id)
        {
            groupViewModel = new GroupDetailsViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel groupModel = db.GroupModels.Find(id);

            List<AppUserModel> appUsersList = db.AppUserModels.Where(x => x.GroupId == groupModel.ID).ToList();
            List<ChatMessage> chatMessageList = db.ChatMessages.Where(x => x.GroupId == groupModel.ID).ToList();
            
            if (groupModel == null)
            {
                return HttpNotFound();
            }
            groupViewModel.GroupName = groupModel.GroupName;
            groupViewModel.GroupMembers = appUsersList;
            groupViewModel.ChatMessageList = chatMessageList;
            return View(groupViewModel);
        }

        // GET: GroupModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GroupName,Active,NumberofMembers")] GroupModel groupModel)
        {
            groupModel.Active = true;
            groupModel.NumberofMembers = 0;
            if (ModelState.IsValid)
            {
                db.GroupModels.Add(groupModel);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(groupModel);
        }

        // GET: GroupModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel groupModel = db.GroupModels.Find(id);
            if (groupModel == null)
            {
                return HttpNotFound();
            }
            return View(groupModel);
        }

        // POST: GroupModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GroupName,Active,NumberofMembers")] GroupModel groupModel)
        {
            groupModel.NumberofMembers = 0;
            groupModel.Active = true;
            if (ModelState.IsValid)
            {
                db.Entry(groupModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(groupModel);
        }

        // GET: GroupModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel groupModel = db.GroupModels.Find(id);
            if (groupModel == null)
            {
                return HttpNotFound();
            }
            return View(groupModel);
        }

        // POST: GroupModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupModel groupModel = db.GroupModels.Find(id);
            db.GroupModels.Remove(groupModel);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
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
