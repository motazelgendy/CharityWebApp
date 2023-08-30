using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Models.ViewModel
{
    public class ChatVM
    {
        public ChatVM()
        {
            Rooms = new List<ChatRoom>();
        }
        public int MaxRoomAllowed { get; set; }
        public IList<ChatRoom> Rooms { get; set; }

        public string? UserId { get; set; }

        public bool AllowAddRoom => Rooms == null || Rooms.Count < MaxRoomAllowed;
    }
}
