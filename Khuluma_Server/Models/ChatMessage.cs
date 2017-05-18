using System;
using System.ComponentModel.DataAnnotations;

namespace Khuluma_Server.Models
{
    public class ChatMessage
    {

        [Key]
        public int ChatId { get; set; }

        public int UserId { get; set; }

        public int GroupId { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string timestampString { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }
        public bool isFlagged { get; set; }
    }
}