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
	public class AppUserRepository : Repository<AppUser>, IAppUserRepository
	{
		private readonly ApplicationDbContext _db;

		public AppUserRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
	}
}
