using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Charity.DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Charity.DataAccess.Data;
using Charity.Models;
using Charity.Utility;

namespace Charity.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ChatRoomsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChatRoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        

        [HttpGet]
        [Route("/[controller]/GetChatUser")]
        public async Task<ActionResult<Object>> GetChatUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
           
            var users = await _context.Users.ToListAsync();

            
                var DoctorsUser = await (from user in _context.Users
                                         join UserRole in _context.UserRoles
                                         on user.Id equals UserRole.UserId
                                         join role in _context.Roles
                                         on UserRole.RoleId equals role.Id
                                         where role.Name =="Doctor"
                                         select user).ToListAsync();


            var NotDoctorUser = await (from user in _context.Users
                                       join UserRole in _context.UserRoles
                                       on user.Id equals UserRole.UserId
                                       join role in _context.Roles
                                       on UserRole.RoleId equals role.Id
                                       where role.Name !="Doctor" && role.Name!="Admin"
                                       select user).ToListAsync();



            if (users == null)
            {
                return NotFound();
            }
            else if (User.IsInRole(UserRole.AdminRole) || User.IsInRole(UserRole.CustomerRole))
            {
                return DoctorsUser.Where(u => u.Id != userId).Select(u => new { u.Id, u.UserName }).ToList();

            }
            else
            {
                return NotDoctorUser.Where(u => u.Id != userId).Select(u => new { u.Id, u.UserName }).ToList();
            }
        }
            
        






    }
}
