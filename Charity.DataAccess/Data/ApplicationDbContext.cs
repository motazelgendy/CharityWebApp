using Charity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace Charity.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Category> categories { get; set; }
    public DbSet<ProgramType> programTypes { get; set; }
    public DbSet<ProgramItem> programitems { get; set; }
    public DbSet<AppUser> appusers { get; set; }
    public DbSet<ShoppingCart> shoppingCarts { get; set; }

    public DbSet<OrderHeader> orderHeader { get;set; }

	public  DbSet<OrderDetails> orderDetails { get; set; }

    public DbSet<BloodBank> bloodBanks { get; set; }

    public DbSet<Volunteer> volunteers { get; set; }


}
