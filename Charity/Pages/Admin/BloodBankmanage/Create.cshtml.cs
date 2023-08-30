using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Charity.DataAccess.Data;
using Charity.Models;
using Charity.DataAccess.Repository.IRepository;
using System.Security.Claims;

namespace Charity.Pages.Admin.BloodBankmanage
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        
        public readonly IUnitOfWork _unitOfWork;

        public BloodBank bloodBank { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            bloodBank = new BloodBank();

        }

        public void OnGet()
        {
            var claimsidentity = (ClaimsIdentity)User.Identity;
            var claims = claimsidentity.FindFirst(ClaimTypes.NameIdentifier);

            AppUser appUser = _unitOfWork.AppUser.GetFirstOrDefault(u => u.Id == claims.Value);

            bloodBank.UserId = appUser.Id;

        }
        public async Task<IActionResult> OnPost()
        {

            
            if (ModelState.IsValid)
            {
                
                _unitOfWork.BloodBank.Add(bloodBank);
                 _unitOfWork.Save();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
