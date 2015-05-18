using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace CeProjectManager
{
    public class ChatHub : Hub
    {
        public void BroadcastMessage(String msgFrom, String msg)
        {
            Clients.All.receiveMessage(msgFrom, msg);
        }

        public void Send(string name, string message)
        {
            if(Clients != null)
                Clients.All.addMessage(name, message); // Call the broadcastMessage method to update clients.
        }
    }
}