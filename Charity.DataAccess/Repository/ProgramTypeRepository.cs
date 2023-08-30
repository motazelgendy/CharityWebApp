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
    public class ProgramTypeRepository : Repository<ProgramType>, IProgramTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public ProgramTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProgramType obj)
        {
            var objFromDb = _db.programTypes.FirstOrDefault(u => u.Id == obj.Id);
            objFromDb.Name = obj.Name;
        }
    }
}
