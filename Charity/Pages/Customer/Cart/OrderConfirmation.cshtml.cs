using Charity.DataAccess.Repository.IRepository;
using Charity.Models;
using Charity.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe.Checkout;

namespace Charity.Pages.Customer.Cart
{
    public class OrderConfirmationModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;

		public int OrderId { get; set; }

		public OrderConfirmationModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public void OnGet(int id)
        {
			OrderHeader orderHeader = _unitOfWork.OrderHeader.GetFirstOrDefault(u => u.Id == id);
			if (orderHeader.SessionId != null)
			{
				var service = new SessionService();
				Session session = service.Get(orderHeader.SessionId);
				if (session.PaymentStatus.ToLower() == "paid")
				{
					orderHeader.Status = PaymentStatus.StatusSubmitted;
					_unitOfWork.Save();
				}
			}
			List<ShoppingCart> shoppingCarts =
				_unitOfWork.ShoppingCart.GetAll(filter: u => u.AppUserId == orderHeader.UserId).ToList();
			_unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
			_unitOfWork.Save();
			OrderId = id;

		}
    }
}
