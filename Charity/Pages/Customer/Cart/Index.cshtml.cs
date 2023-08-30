using Charity.DataAccess.Repository.IRepository;
using Charity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charity.Pages.Customer.Cart
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        public double CartTotal { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void OnGet()
        {
            var claimsidentity = (ClaimsIdentity)User.Identity;
            var claims = claimsidentity.FindFirst(ClaimTypes.NameIdentifier);

            if(claims != null)
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(filter: m => m.AppUserId == claims.Value,
               IncludeProperties : "ProgramItem,ProgramItem.ProgramType,ProgramItem.Category");

                foreach (var cartItem in ShoppingCartList)
                {
                    CartTotal += (cartItem.ProgramItem.Price * cartItem.Count);
                }
            }
        }
         public IActionResult OnPostPlus(int cartId)
		{
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
            _unitOfWork.ShoppingCart.IncrementCount(cart,1);
            return RedirectToPage("/Customer/Cart/Index");
        }
        public IActionResult OnPostMinus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
			if (cart.Count == 1)
			{
                var count = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.AppUserId == cart.AppUserId);

                _unitOfWork.ShoppingCart.Remove(cart);
                _unitOfWork.Save();
              
            }
			else
			{
                _unitOfWork.ShoppingCart.DecrementCount(cart, 1);
            }
            return RedirectToPage("/Customer/Cart/Index");
        }
        public IActionResult OnPostRemove(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);


            var count = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.AppUserId == cart.AppUserId);

            _unitOfWork.ShoppingCart.Remove(cart);
            _unitOfWork.Save();
            return RedirectToPage("/Customer/Cart/Index");
        }
    }
}
