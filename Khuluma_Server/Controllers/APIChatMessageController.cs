using System.Web.Http;
using Khuluma_Server.Models.apiModels;
using System.Collections.Generic;
using Khuluma_Server.Models;
using System.Linq;

namespace Khuluma_Server.Controllers
{
    public class APIChatMessageController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<ChatMessageAPIModel> GetAll()
        {
            //Query Results
           

            var chatList = from u in new ApplicationDbContext().ChatMessages
                           
                           select new ChatMessageAPIModel
                           {
                               ChatMessageAPIModelId = u.ChatId,
                               UserId = u.UserId,
                               GroupId = u.GroupId,
                               Name = u.Name,
                               Message = u.Message,
                               MessageTimestamp = u.timestampString
                               
            };

            return (chatList.ToList());

        }
        //APIChatMessages/2/groupMessages
        [Route("APIChatMessages/{groupId}/groupMessages")]
        public IEnumerable<ChatMessageAPIModel> GetAllByGroupId(int? GroupId)
        {
            //Query Results


            var chatList = from u in new ApplicationDbContext().ChatMessages
                           where u.GroupId == GroupId
                           select new ChatMessageAPIModel
                           {
                               ChatMessageAPIModelId = u.ChatId,
                               UserId = u.UserId,
                               GroupId = u.GroupId,
                               Name = u.Name,
                               Message = u.Message,
                               MessageTimestamp = u.timestampString
                           };

            return (chatList.ToList());

        }

    }
}
