using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charity.DataAccess.Data;
using Charity.DataAccess.Repository.IRepository;
using Charity.Models;

namespace Charity.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
          ProgramType = new ProgramTypeRepository(_db);
            ProgramItem = new ProgramItemRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
			OrderHeader = new OrderHeaderRepository(_db);
			OrderDetails = new OrderDetailsRepository(_db);
            AppUser = new AppUserRepository(_db);
            BloodBank = new BloodBankRepository(_db);
            volunteer = new VolunteerRepository(_db);


        }

        public ICategoryRepository Category { get; private set; }

        public IProgramTypeRepository ProgramType { get; private set; }
        public IProgramItemRepository ProgramItem { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }   
        public IOrderDetailsRepository OrderDetails { get; private set; } 
        public IAppUserRepository AppUser { get;private set; }
        public IBloodBankRepository BloodBank { get; private set; }
        public IvolunteerRepository volunteer { get; private set; }





        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
