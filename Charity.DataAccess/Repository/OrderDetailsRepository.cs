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
	public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
	{
		private readonly ApplicationDbContext _db;

		public OrderDetailsRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(OrderDetails obj)
		{
			_db.orderDetails.Update(obj);
		}
	}
}
