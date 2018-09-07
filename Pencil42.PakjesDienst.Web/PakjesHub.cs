using Amqp;
using Microsoft.AspNetCore.SignalR;

namespace Pencil42.PakjesDienst.Web
{
    public class PakjesHub : Hub
    {
        public async void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("broadcastMessage", name, message);
        }

        public async void InvokeMethod()
        {

        }
    }
}