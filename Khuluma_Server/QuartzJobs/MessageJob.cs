using Khuluma_Server.Hubs;
using Khuluma_Server.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Khuluma_Server.QuartzJobs
{
    public class MessageJob : IJob
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ChatMessage chatMessage = new ChatMessage();
        private DateTime timestamp;
        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
        
        public async void Execute(IJobExecutionContext context)
        {
            
            var messageList = db.PredefinedMessageModels.ToList();
           
            foreach (var item in messageList)
            {
                timestamp = new DateTime();
                timestamp = DateTime.UtcNow.AddHours(2.0);

                int[] idVals = new int[4];

                // Group Id
                idVals[0] = item.Group.ID;
                // User Id
                idVals[1] = 1;

                int hourNow = timestamp.Hour;
                int hourMessage = item.time.Hour;

                Debug.WriteLine("HOUR NOW: {0}", hourNow);
                Debug.WriteLine("HOUR MESSAGE: {0}", hourMessage);

                if (hourNow == hourMessage)
                {
                    hubContext.Clients.All.addNewMessageToPage("Khuluma", item.MessageText, timestamp, idVals);

                    SendNotificationFromFirebaseCloud("Khuluma", item.MessageText, item.Group.ID);
                }

                

                Debug.WriteLine("AUTO MESSAGE SENT: {0}", timestamp);

              
            }

            
        }

        private void SendNotificationFromFirebaseCloud(string msgTitle, string messageBody, int groupID)
        {
            try
            {
                string groupIdString = groupID.ToString();
                var applicationID = "AAAA3VTw6YM:APA91bFU9eicJNlwOuC7lT6a2w61jJTICoszUwZEdnEBPH_9Ypckrla4XYY3Qp40yMgt1wJHzznHYliR8F-yYqwDQWyRHE-3sINHgdiu-vwWzzAPqYO3yKBdzMh7gFmZBEQ_-GjeKnrW";
                string messageTitle = "New message from " + msgTitle;
                var senderId = "950612846979";

                string deviceId = "fDSa7G0AkgA:APA91bGV3XKIuphW2-bQh_NeGvsMyFtEIRAj1TMS8mob0e9V_MmK-Vu1UorpAjvZKbbFuAzgTYPL9bneNmx8PG3J7V7zeei3lIQ6Cf8ummtfVA-2hCX_Eke0jrrHgU1wshu5Rw1Uh-AE";

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

                tRequest.Method = "post";

                tRequest.ContentType = "application/json";

                var data = new

                {

                    //to = deviceId,
                    //to = "cFno8ViUa_w:APA91bEXFMgPwddXb8aY1JXEfsQSBXcYWGYevcQkeqYd9b9tBuT6jJIcWkLZT3RPJlT3nfmIoPmoMqY-slNaHj4hi471MdAov2MOqXVSc50ugz0BEsM9FcygOEe-9YGO5uDZEMfNBVyw",
                    to = "/topics/" + groupIdString,
                    notification = new

                    {

                        body = messageBody,

                        title = messageTitle

                    }
                };

                var serializer = new JavaScriptSerializer();

                var json = serializer.Serialize(data);

                Byte[] byteArray = Encoding.UTF8.GetBytes(json);

                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));

                tRequest.ContentLength = byteArray.Length;


                using (Stream dataStream = tRequest.GetRequestStream())
                {

                    dataStream.Write(byteArray, 0, byteArray.Length);


                    using (WebResponse tResponse = tRequest.GetResponse())
                    {

                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {

                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {

                                String sResponseFromServer = tReader.ReadToEnd();

                                string str = sResponseFromServer;

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                string str = ex.Message;

            }
        }
    }



}