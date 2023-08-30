using Charity.DataAccess.Data;
using Charity.DataAccess.Repository.IRepository;
using Charity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.DataAccess.Repository
{
    public class BloodBankRepository : Repository<BloodBank>, IBloodBankRepository
    {
        private readonly ApplicationDbContext _db;

        public BloodBankRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(BloodBank bloodBank)
        {
            var objfromDB = _db.bloodBanks.FirstOrDefault(u => u.Id == bloodBank.Id);

            objfromDB.Name = bloodBank.Name;
            objfromDB.Address = bloodBank.Address;
            objfromDB.Latitude = bloodBank.Latitude;
            objfromDB.Longitude = bloodBank.Longitude;


        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }

}

