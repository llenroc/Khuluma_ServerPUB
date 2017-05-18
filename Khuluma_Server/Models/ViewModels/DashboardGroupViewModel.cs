using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Khuluma_Server.Models.ViewModels
{
    public class DashboardGroupViewModel
    {
        //public int DashboardGroupViewModelId { get; set; }

        [Display(Name = "Group")]
        public string GroupName { get; set; }
        [Display(Name = "Total: Members")]
        public int TotalMembers { get; set; }
        [Display(Name = "Total: Messages")]
        public int TotalMessages { get; set; }

        [Display(Name = "Total: Flagged")]
        public int TotalFlaggedMessages { get; set; }

        [Display(Name = "Last Active")]
        public String LastMessage { get; set; }

    }
}