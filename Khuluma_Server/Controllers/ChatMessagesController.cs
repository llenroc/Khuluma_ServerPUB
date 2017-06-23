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
        public List<ChatMessage> messageList;
        public List<ChatMessageViewModel> messageListVM;
        public List<AppUserModel> appUserList;
        AppUserModel user;
        ChatMessageViewModel chatItem;

        // GET: ChatMessages
        public ActionResult Index()
        {
            messageListVM = new List<ChatMessageViewModel>();
            messageList = new List<ChatMessage>();

            messageList = db.ChatMessages.ToList();
            appUserList = db.AppUserModels.ToList();
            ChatMessageViewModel chatMessage = new ChatMessageViewModel(); ;
            foreach (ChatMessage u in messageList)
            {
                user = appUserList.Find(x => x.ID == u.UserId);
                chatItem = new ChatMessageViewModel();
                chatItem.Id = u.ChatId;
                chatItem.Date = u.TimeStamp.ToShortDateString();
                chatItem.Time = u.TimeStamp.ToLongTimeString();
                chatItem.Name = u.Name;
                chatItem.Message = u.Message;
                chatItem.isFlagged = u.isFlagged;
                chatItem.UserName = user.Name;
                chatItem.GroupName = user.Group.GroupName;

                messageListVM.Add(chatItem);

            }



            return View(messageListVM.ToList());

            //return View(db.ChatMessages.ToList());
        }

        public void ExcelAction(string GridModel)

        {

            ExcelExport exp = new ExcelExport();

            messageListVM = new List<ChatMessageViewModel>();

            messageList = db.ChatMessages.ToList();
            appUserList = db.AppUserModels.ToList();
            ChatMessageViewModel chatMessage = new ChatMessageViewModel(); ;
            foreach (ChatMessage u in messageList)
            {
                user = appUserList.Find(x => x.ID == u.UserId);
                chatItem = new ChatMessageViewModel();
                chatItem.Id = u.ChatId;
                chatItem.Date = u.TimeStamp.ToShortDateString();
                chatItem.Time = u.TimeStamp.ToLongTimeString();
                chatItem.Name = u.Name;
                chatItem.Message = u.Message;
                chatItem.isFlagged = u.isFlagged;
                chatItem.UserName = user.Name;
                chatItem.GroupName = user.Group.GroupName;

                messageListVM.Add(chatItem);

            }




            var DataSource = messageListVM.ToList();
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
