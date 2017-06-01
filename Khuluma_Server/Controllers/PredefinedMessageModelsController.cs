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
    public class PredefinedMessageModelsController : Controller
    {
        public List<PredefinedMessageModel> messageList;
        public List<AutoMessageViewModel> messageListVM;
        private ApplicationDbContext db = new ApplicationDbContext();
        private AutoMessageViewModel autoMessage;
        //public IEnumerable<AutoMessageViewModel> messageList;

        // GET: PredefinedMessageModels
        public ActionResult Index()
        {
            string timeHour;
            string groupName;
            int groupId;
            
            messageList = new List<PredefinedMessageModel>();
            messageListVM = new List<AutoMessageViewModel>();

            messageList = db.PredefinedMessageModels.ToList();

            foreach (PredefinedMessageModel msg in messageList)
            {
                autoMessage = new AutoMessageViewModel();

                timeHour = msg.time.ToShortTimeString();
                groupName = msg.Group.GroupName;
                groupId = msg.Group.ID;

                autoMessage.AutoMessageId = msg.ID;
                autoMessage.MessageText = msg.MessageText;
                autoMessage.time = timeHour;
                autoMessage.GroupName = groupName;
                autoMessage.GroupId = groupId;

                messageListVM.Add(autoMessage);
            }

            /*var messageList = from u in new ApplicationDbContext().PredefinedMessageModels
                           select new AutoMessageViewModel
                           {
                               MessageText = u.MessageText,
                               GroupId = u.GroupId,
                               GroupName = u.Group.GroupName,
                               AutoMessageId = u.ID,
                               time = u.time.
                           };*/

            //var predefinedMessageModels = db.PredefinedMessageModels.Include(p => p.Group);
            return View(messageListVM.ToList());
        }

        // GET: PredefinedMessageModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PredefinedMessageModel predefinedMessageModel = db.PredefinedMessageModels.Find(id);
            if (predefinedMessageModel == null)
            {
                return HttpNotFound();
            }
            return View(predefinedMessageModel);
        }

        // GET: PredefinedMessageModels/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.GroupModels, "ID", "GroupName");
            return View();
        }

        // POST: PredefinedMessageModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MessageText,GroupId,time")] PredefinedMessageModel predefinedMessageModel)
        {
            if (ModelState.IsValid)
            {
                db.PredefinedMessageModels.Add(predefinedMessageModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.GroupModels, "ID", "GroupName", predefinedMessageModel.GroupId);
            return View(predefinedMessageModel);
        }

        // GET: PredefinedMessageModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PredefinedMessageModel predefinedMessageModel = db.PredefinedMessageModels.Find(id);
            if (predefinedMessageModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.GroupModels, "ID", "GroupName", predefinedMessageModel.GroupId);
            return View(predefinedMessageModel);
        }

        // POST: PredefinedMessageModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MessageText,GroupId,time")] PredefinedMessageModel predefinedMessageModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predefinedMessageModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.GroupModels, "ID", "GroupName", predefinedMessageModel.GroupId);
            return View(predefinedMessageModel);
        }

        // GET: PredefinedMessageModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PredefinedMessageModel predefinedMessageModel = db.PredefinedMessageModels.Find(id);
            if (predefinedMessageModel == null)
            {
                return HttpNotFound();
            }
            return View(predefinedMessageModel);
        }

        // POST: PredefinedMessageModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PredefinedMessageModel predefinedMessageModel = db.PredefinedMessageModels.Find(id);
            db.PredefinedMessageModels.Remove(predefinedMessageModel);
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
