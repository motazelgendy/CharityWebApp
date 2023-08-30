using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get;}
        IProgramTypeRepository ProgramType { get;}
        IProgramItemRepository ProgramItem { get;}
        IShoppingCartRepository ShoppingCart { get;}
        IOrderDetailsRepository OrderDetails { get;}
        IOrderHeaderRepository OrderHeader { get;}  
        IAppUserRepository AppUser { get;}
        IBloodBankRepository BloodBank { get; }
        IvolunteerRepository volunteer { get;}
        
        void Save();
    }
}
