using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khuluma_Server.Models.ViewModels
{
    public class GroupDetailsViewModel
    {
        public int GroupDetailsViewModelId { get; set; }
        public string GroupName { get; set; }

        public List<AppUserModel> GroupMembers { get; set; }
        public List<ChatMessage> ChatMessageList { get; set; }
    }
}