using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageHub
{
    public class ImageHub:Hub
    {
        public void Send(string blobUrl)
        {
            Clients.All.broadcastImage(blobUrl);
        }
    }
}