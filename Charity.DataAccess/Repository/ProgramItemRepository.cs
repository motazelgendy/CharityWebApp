using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charity.DataAccess.Repository.IRepository;
using Charity.Models;
using Charity.DataAccess.Data;

namespace Charity.DataAccess.Repository
{
    public class ProgramItemRepository : Repository<ProgramItem>, IProgramItemRepository
    {
        private readonly ApplicationDbContext _db;

        public ProgramItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProgramItem obj)
        {
            var objFromDb = _db.programitems.FirstOrDefault(u => u.Id == obj.Id);
            objFromDb.Name = obj.Name;
            objFromDb.Description = obj.Description;
            objFromDb.Price = obj.Price;
            objFromDb.CategoryId = obj.CategoryId;
            objFromDb.ProgramTypeId = obj.ProgramTypeId;
            if(objFromDb.Image != null)
            {
                objFromDb.Image = objFromDb.Image;
            }
           
        }
    }
}
