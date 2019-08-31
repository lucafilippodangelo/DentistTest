using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistCore2._2.SignalR
{
    //LD SR
    public class AnHub : Hub
    {
        /// <summary>
        /// The SendMessage method can be called by a connected client to send a message to all clients.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string user, string message, string alertTypeInput)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, alertTypeInput);
        }
    }
}
