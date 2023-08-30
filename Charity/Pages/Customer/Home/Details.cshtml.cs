using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Charity.DataAccess.Repository.IRepository;
using Charity.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Charity.Pages.Customer.Home
{
    [Authorize]
    public class DetailsModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;


        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public ShoppingCart ShoppingCart { get; set; }


        
        public void OnGet(int id)
        {
            var calimsidentity = (ClaimsIdentity)User.Identity;
            var claims = calimsidentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCart = new()
            {
                AppUserId = claims.Value,
                ProgramItem = _unitOfWork.ProgramItem.GetFirstOrDefault(s => s.Id == id, IncludeProperties: "Category,ProgramType"),
                ProgramItemId = id,
                Count = 1
            };
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ShoppingCart shoppingCartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
                   filter: u => u.AppUserId == ShoppingCart.AppUserId &&
                    u.ProgramItemId == ShoppingCart.ProgramItemId);

                if (shoppingCartFromDb == null)
                {

                    _unitOfWork.ShoppingCart.Add(ShoppingCart);
                    _unitOfWork.Save();
                    
                }
                else
                {
                    _unitOfWork.ShoppingCart.IncrementCount(shoppingCartFromDb, ShoppingCart.Count);
                }
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}

