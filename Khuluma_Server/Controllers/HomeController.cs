using Khuluma_Server.Models;
using Khuluma_Server.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Khuluma_Server.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public List<GroupModel> groupList;
        public List<DashboardGroupViewModel> dashboardGroupViewModelList;
        private List<AppUserModel> appUsersList;
        private List<ChatMessage> chatMessagesList;
        ChatMessage lastMessage;
        String timeofLastMessage;
        int lastIndex;

        public ActionResult Index()
        {
            groupList = new List<GroupModel>();
            dashboardGroupViewModelList = new List<DashboardGroupViewModel>();
            appUsersList = new List<AppUserModel>();

            groupList = db.GroupModels.ToList();

            foreach (GroupModel group in groupList)
            {
                appUsersList = db.AppUserModels.Where(x => x.GroupId == group.ID).ToList();
                chatMessagesList = db.ChatMessages.Where(x => x.GroupId == group.ID).ToList();

                if (chatMessagesList.Count()>0)
                {
                    lastIndex = chatMessagesList.Count - 1;
                    lastMessage = chatMessagesList.ElementAt(lastIndex);
                    timeofLastMessage = lastMessage.TimeStamp.ToString();
                } else
                {
                    timeofLastMessage = "No messages yet";
                }

               

                dashboardGroupViewModelList.Add(new DashboardGroupViewModel()
                {

                    DashboardGroupViewModelId = group.ID,
                    GroupName = group.GroupName,
                    TotalMembers = appUsersList.Count(),
                    TotalMessages = chatMessagesList.Count(),
                    LastMessage = timeofLastMessage


                });
            }
            ViewBag.groups = dashboardGroupViewModelList;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Chat(int? id)
        {
            if (!id.HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            GroupModel groupModel = db.GroupModels.Find(id);
            ViewBag.GroupName = groupModel.GroupName;
            ViewBag.GroupId = groupModel.ID;

            var messageList = from u in new ApplicationDbContext().ChatMessages
                              where u.GroupId == id
                              select new ChatMessageViewModel
                              {
                                  Id = u.ChatId,
                                 
                                  Date = u.Date,
                                  Time = u.Time,
                                  Name = u.Name,
                                  Message = u.Message,
                                  isFlagged = u.isFlagged


                              };

            

            return View(messageList.ToList());
        }

    }
}