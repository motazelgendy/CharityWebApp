using Charity.DataAccess.Data;
using Charity.Models;
using Charity.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

            }

            if (!_roleManager.RoleExistsAsync(UserRole.AdminRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(UserRole.CustomerRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(UserRole.AdminRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(UserRole.DoctorRole)).GetAwaiter().GetResult();


                _userManager.CreateAsync(new AppUser
                {
                    UserName = "admin@charity.com",
                    Email = "admin@charity.com",
                    EmailConfirmed = true,
                    FirstName = "Motaz",
                    LastName = "Elgendy"
                }, "Admin123*").GetAwaiter().GetResult();

                AppUser user = _db.appusers.FirstOrDefault(u => u.Email == "admin@charity.com");

                _userManager.AddToRoleAsync(user, UserRole.AdminRole).GetAwaiter().GetResult();

            }

        }
    }
}
