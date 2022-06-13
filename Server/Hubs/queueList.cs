using Microsoft.AspNetCore.SignalR;

namespace Procuts.Server.Hubs
{
	public class queueList : Hub
	{

		public override async Task OnConnectedAsync()
        {
			await SendMessage("", "User Connected!");
			await base.OnConnectedAsync();
        }

		public async Task SendMessage(string user, string message)
        {
			await Clients.All.SendAsync("Update", user, message);
        }
	}
}

