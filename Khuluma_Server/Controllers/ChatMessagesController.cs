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
using Syncfusion.EJ.Export;
using Syncfusion.JavaScript.Models;
using Syncfusion.XlsIO;





namespace Khuluma_Server.Controllers
{
    [Authorize]
    public class ChatMessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //public IEnumerable<ChatMessageViewModel> messageList;

        // GET: ChatMessages
        public ActionResult Index()
        {


            var messageList = from u in new ApplicationDbContext().ChatMessages
                           select new ChatMessageViewModel
                           {
                                Id = u.ChatId,
                                UserId = u.UserId,
                                GroupId = u.GroupId,
                                Date = u.Date,
                                Time = u.Time,
                                Name = u.Name,
                                Message = u.Message,
                                isFlagged = u.isFlagged
                                

                            };

            return View(messageList.ToList());

            //return View(db.ChatMessages.ToList());
        }

        public void ExcelAction(string GridModel)

        {

            ExcelExport exp = new ExcelExport();

            //var DataSource = db.ChatMessages.ToList();

            var messageList = from u in new ApplicationDbContext().ChatMessages
                              select new ChatMessageViewModel
                              {
                                  Id = u.ChatId,
                                  UserId = u.UserId,
                                  GroupId = u.GroupId,
                                  Date = u.Date,
                                  Time = u.Time,
                                  Name = u.Name,
                                  Message = u.Message

                              };
            var DataSource = messageList.ToList();
            GridProperties obj = (GridProperties)Syncfusion.JavaScript.Utils.DeserializeToModel(typeof(GridProperties), GridModel);

            exp.Export(obj, DataSource, "Export.xlsx", ExcelVersion.Excel2010, false, false, "flat-saffron");

        }

        

        // GET: ChatMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatMessage chatMessage = db.ChatMessages.Find(id);
            if (chatMessage == null)
            {
                return HttpNotFound();
            }
            return View(chatMessage);
        }

        // GET: ChatMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChatMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChatId,UserId,GroupId,TimeStamp,timestampString,Name,Message")] ChatMessage chatMessage)
        {
            if (ModelState.IsValid)
            {
                db.ChatMessages.Add(chatMessage);

                //Notifications Hub - PUSH
                // Get the settings for the server project.
                

                //////////////////////////////
                /////////////////////////
                ////////////////////////




                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chatMessage);
        }

        // GET: ChatMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatMessage chatMessage = db.ChatMessages.Find(id);
            if (chatMessage == null)
            {
                return HttpNotFound();
            }
            return View(chatMessage);
        }

        // POST: ChatMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChatId,UserId,GroupId,TimeStamp,timestampString,Name,Message")] ChatMessage chatMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chatMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chatMessage);
        }

        // GET: ChatMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatMessage chatMessage = db.ChatMessages.Find(id);
            if (chatMessage == null)
            {
                return HttpNotFound();
            }
            return View(chatMessage);
        }

        // POST: ChatMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChatMessage chatMessage = db.ChatMessages.Find(id);
            db.ChatMessages.Remove(chatMessage);
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
