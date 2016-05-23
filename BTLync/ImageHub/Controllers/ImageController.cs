using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ImageHub.Controllers
{
    public class ImageController : ApiController
    {
        public string Get(string blobUrl)
        {
            try
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<ImageHub>();
                context.Clients.All.broadcastImage(blobUrl);
                return ("Broadcast done!");
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
