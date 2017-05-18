using System;
using System.ComponentModel.DataAnnotations;

namespace Khuluma_Server.Models
{
    public class PredefinedMessageModel
    {
        public int ID { get; set; }

        [Display(Name = "Message")]
        public string MessageText { get; set; }

        public int? GroupId { get; set; }

        public virtual GroupModel Group { get; set; }

        public DateTime time { get; set; }
    }
}