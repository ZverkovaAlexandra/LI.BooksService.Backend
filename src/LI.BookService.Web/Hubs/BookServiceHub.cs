using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace LI.BookService.Hubs
{
    public class BookServiceHub : Hub
    {
        // ----- Example -----
        public async Task Send(string message, string userName)
        {
            await Clients.All.SendAsync("Send", message, userName);
        }
    }
}
