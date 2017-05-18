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


        [Display(Name = "Participant ID")]
        public string ParticipantId { get; set; }

        public string LocationName { get; set; }
        public string GroupName { get; set; }

    }
}