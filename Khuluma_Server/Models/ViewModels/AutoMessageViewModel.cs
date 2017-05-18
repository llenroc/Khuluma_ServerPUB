using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Khuluma_Server.Models.ViewModels
{
    public class AutoMessageViewModel
    {
        public int AutoMessageId { get; set; }

        [Display(Name = "Message")]
        public string MessageText { get; set; }

        public string GroupName { get; set; }

        public int? GroupId { get; set; }

        public string time { get; set; }
    }
}