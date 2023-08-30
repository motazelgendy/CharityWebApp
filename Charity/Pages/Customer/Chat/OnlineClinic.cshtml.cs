using Charity.DataAccess.Data;
using Charity.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charity.Pages.Customer.Chat
{
    [Authorize]
    public class OnlineClinicModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        public void OnGet()
        {
           // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ChatVM chatVm = new()
            //{
            //    Rooms = _context.ChatRoom.ToList(),
            //    MaxRoomAllowed = 4,
            //    UserId = userId,
            //};


        }
    }
}
