using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeMessanger.Models;

namespace ZeMessanger.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message Message) =>
            await Clients.All.SendAsync("receiveMessage", Message);
    }
}
