using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ClientServer
{
    public class ChatHub : Hub
    {
        //User count
        private static int userCount = 0;

        public void Send(string name, string message)
        {
            //Command?
            if (message == "/usercount")
            {
                //Send user count
                Clients.All.broadcastMessage("ADMIN", "There are " + userCount.ToString() + " users online.");
            }

            //Broadcast the message to all clients
            Clients.All.broadcastMessage(name, message);
        }

        public void NewConnection(string name)
        {
            Clients.All.newConnection(name);
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            userCount++;
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {
            userCount--;
            return base.OnDisconnected();
        }
    }
}