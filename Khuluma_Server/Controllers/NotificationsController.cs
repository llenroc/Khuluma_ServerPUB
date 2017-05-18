using Khuluma_Server.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Khuluma_Server.Controllers
{
    public class NotificationsController : ApiController
    {

        public async Task<HttpResponseMessage> Post(string pns, [FromBody]string message, string to_tag)
        {
            var user = HttpContext.Current.User.Identity.Name;
            user = "HENRY";

            string[] userTag = new string[2];
            userTag[0] = "username:" + to_tag;
            userTag[1] = "from:" + user;

            Microsoft.Azure.NotificationHubs.NotificationOutcome outcome = null;
            HttpStatusCode ret = HttpStatusCode.InternalServerError;

            // Android
            var notif = "{ \"data\" : {\"message\":\"" + "From " + user + ": " + message + "\"}}";
            //outcome = await Notifications.Instance.Hub.SendGcmNativeNotificationAsync(notif, userTag);

            //outcome = await Notifications.Instance.Hub.SendGcmNativeNotificationAsync(notif);

            Dictionary<string, string> templateParams = new Dictionary<string, string>();

            string category = "Music";

            templateParams["messageParam"] = "Breaking " + category + " News!";
            outcome = await Notifications.Instance.Hub.SendTemplateNotificationAsync(templateParams);

           

            if (outcome != null)
            {
                if (!((outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Abandoned) ||
                    (outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Unknown)))
                {
                    ret = HttpStatusCode.OK;
                }
            }

            return Request.CreateResponse(ret);
        }

    }
}
