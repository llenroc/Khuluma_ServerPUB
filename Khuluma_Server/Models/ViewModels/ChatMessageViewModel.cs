using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Khuluma_Server.Models.ViewModels
{
    public class ChatMessageViewModel
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ChatMessageViewModel()
        {
            
        }
        public int Id { get; set; }

        //public int UserId { get; set; }
        [Display(Name = "User")]
        public string UserName { get; set; }

        //public int GroupId { get; set; }
        [Display(Name = "Group")]
        public string GroupName { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public bool isFlagged { get; set; }
    }
}