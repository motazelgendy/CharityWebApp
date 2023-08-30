using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charity.Models;
using Charity.DataAccess.Repository.IRepository;
using Charity.DataAccess.Data; 

namespace Charity.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var objfromDB = _db.categories.FirstOrDefault(u => u.Id == category.Id);

            objfromDB.Name = category.Name;
            objfromDB.DisplayOrder = category.DisplayOrder;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
