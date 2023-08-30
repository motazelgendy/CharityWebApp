using Charity.DataAccess.Repository.IRepository;
using Charity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Charity.Utility;
using Stripe.Checkout;

namespace Charity.Pages.Customer.Cart
{
	public class SummaryModel : PageModel
	{
		public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
		public OrderHeader OrderHeader { get; set; }
		private readonly IUnitOfWork _unitOfWork;
		public SummaryModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			OrderHeader = new OrderHeader();
		}


		public void OnGet()
		{
			var claimsidentity = (ClaimsIdentity)User.Identity;
			var claims = claimsidentity.FindFirst(ClaimTypes.NameIdentifier);

			if (claims != null)
			{
				ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(filter: m => m.AppUserId == claims.Value,
			   IncludeProperties: "ProgramItem,ProgramItem.ProgramType,ProgramItem.Category");

				foreach (var cartItem in ShoppingCartList)
				{
					OrderHeader.OrderTotal += (cartItem.ProgramItem.Price * cartItem.Count);
				}
				AppUser appUser = _unitOfWork.AppUser.GetFirstOrDefault(u => u.Id == claims.Value); //this to get user data




			}



			
		}


		public IActionResult OnPost()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			if (claim != null)
			{
				ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(filter: u => u.AppUserId == claim.Value,
					IncludeProperties: "ProgramItem,ProgramItem.ProgramType,ProgramItem.Category");

				foreach (var cartItem in ShoppingCartList)
				{
					OrderHeader.OrderTotal += (cartItem.ProgramItem.Price * cartItem.Count);
				}

				OrderHeader.Status = PaymentStatus.StatusPending;
				OrderHeader.OrderDate = System.DateTime.Now;
				OrderHeader.UserId = claim.Value;
				_unitOfWork.OrderHeader.Add(OrderHeader);
				_unitOfWork.Save();

				foreach (var item in ShoppingCartList)
				{
					OrderDetails orderDetails = new()
					{
						ProgramItemId = item.ProgramItemId,
						OrderId = OrderHeader.Id,
						Name = item.ProgramItem.Name,
						Price = item.ProgramItem.Price,
						Count = item.Count

					};

					_unitOfWork.OrderDetails.Add(orderDetails);
					_unitOfWork.Save();
				}
				
				//_unitOfWork.ShoppingCart.RemoveRange(ShoppingCartList);
			
				_unitOfWork.Save();


				var domain = "http://localhost:59961/";
				var options = new Stripe.Checkout.SessionCreateOptions
				{
					LineItems = new List<SessionLineItemOptions>
				{
				  new SessionLineItemOptions
				  {
					PriceData = new SessionLineItemPriceDataOptions
					{
						UnitAmount = (long)(OrderHeader.OrderTotal*100),
						Currency ="egp",
						ProductData = new SessionLineItemPriceDataProductDataOptions
						{
							Name = "CharityApp Donation",
						



						},




					},
					Quantity=1


				  },
				  
				},
					

					Mode = "payment",
					SuccessUrl = domain + $"customer/cart/OrderConfirmation?id={OrderHeader.Id}",
					CancelUrl = domain + "customer/cart/index",
					
				};
				var service = new SessionService();
				Session session = service.Create(options);

				Response.Headers.Add("Location", session.Url);
				OrderHeader.SessionId = session.Id;
				OrderHeader.PaymentIntentId = session.PaymentIntentId;
				_unitOfWork.Save();
				return new StatusCodeResult(303);


			}


			return Page();
		}
	}
}
