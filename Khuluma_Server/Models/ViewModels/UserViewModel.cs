using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Khuluma_Server.Models.ViewModels
{
    public class UserViewModel
    {
        [Key]
        [Display(Name = "Number")]
        public int ID { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        [Display(Name = "Location")]
        public string LocationName { get; set; }
        [Display(Name = "Group")]
        public string GroupName { get; set; }
        [Display(Name = "Total Messages")]
        public int TotalMessages { get; set; }
        [Display(Name = "Total Flagged Messages")]
        public int TotalFlaggedMessages {get; set;}

    }
}