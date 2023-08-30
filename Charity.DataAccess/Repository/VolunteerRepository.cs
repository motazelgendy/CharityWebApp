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
    public class VolunteerRepository : Repository<Volunteer>, IvolunteerRepository
    {
        private readonly ApplicationDbContext _db;
        public VolunteerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Volunteer volunteer)
        {
            var objfromDB = _db.volunteers.FirstOrDefault(u => u.Id == volunteer.Id);

            objfromDB.FirstName = volunteer.FirstName;
            objfromDB.LastName = volunteer.LastName;
            objfromDB.Email = volunteer.Email;
            objfromDB.Age = volunteer.Age;
            objfromDB.PhoneNumber = volunteer.PhoneNumber;


        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
