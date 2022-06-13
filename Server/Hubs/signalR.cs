using Microsoft.AspNetCore.SignalR;
using Procuts.Server.Data;

namespace Procuts.Server.Hubs
{
	public class signalR : Hub
	{

        public async Task addUser(string user)
        {
            myQue.addUser(user);
            await Clients.All.SendAsync("Update", myQue.current);
        }

        public async Task rmUser()
        {
            myQue.rmUser();
            await Clients.All.SendAsync("Update", myQue.current);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await Clients.All.SendAsync("Update", myQue.current);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}

