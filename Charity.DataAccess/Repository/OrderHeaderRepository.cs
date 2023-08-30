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
	public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
	{
		private readonly ApplicationDbContext _db;

		public OrderHeaderRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(OrderHeader obj)
		{
			_db.orderHeader.Update(obj);
		}

		public void UpdateStatus(int id, string status)
		{
			var orderFromDb = _db.orderHeader.FirstOrDefault(u => u.Id == id);
			if (orderFromDb != null)
			{
				orderFromDb.Status = status;
			}
		}
	}
}

