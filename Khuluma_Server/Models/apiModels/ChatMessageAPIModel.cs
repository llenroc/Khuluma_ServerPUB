using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khuluma_Server.Models.apiModels
{
    public class ChatMessageAPIModel
    {
        public int ChatMessageAPIModelId { get; set; }

        public int UserId { get; set; }

        public int GroupId { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public string MessageTimestamp { get; set; }

    }
}