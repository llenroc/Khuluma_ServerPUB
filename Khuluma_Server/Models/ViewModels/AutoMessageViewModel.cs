using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Khuluma_Server.Models.ViewModels
{
    public class AutoMessageViewModel
    {
        [Display(Name = "ID")]
        public int AutoMessageId { get; set; }

        [Display(Name = "Message")]
        public string MessageText { get; set; }
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }
        [Display(Name = "Group ID")]
        public int? GroupId { get; set; }
        [Display(Name = "Time")]
        public string time { get; set; }
    }
}