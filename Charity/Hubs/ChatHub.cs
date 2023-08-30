using Charity.DataAccess.Data;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Charity.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _db;
        public ChatHub(ApplicationDbContext db)
        {
            _db = db;
        }

      


        public async Task SendPrivateMessage(string receiverId, string message, string receiverName)
        {
            var senderId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var senderName = _db.Users.FirstOrDefault(u => u.Id == senderId).UserName;

            var users = new string[] { senderId, receiverId };

            await Clients.Users(users).SendAsync("ReceivePrivateMessage", senderId, senderName, receiverId, message, Guid.NewGuid(), receiverName);
        }

       
    }
}
