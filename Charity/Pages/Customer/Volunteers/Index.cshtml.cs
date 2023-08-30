using Charity.DataAccess.Repository.IRepository;
using Charity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charity.Pages.Customer.Volunteers
{
    [BindProperties]
    [Authorize]
    public class IndexModel : PageModel
    {


        public readonly IUnitOfWork _unitOfWork;
        public Volunteer volunteer { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            volunteer = new Volunteer();



        }
        public void OnGet()
        {
            var claimsidentity = (ClaimsIdentity)User.Identity;
            var claims = claimsidentity.FindFirst(ClaimTypes.NameIdentifier);

            AppUser appUser = _unitOfWork.AppUser.GetFirstOrDefault(u => u.Id == claims.Value);

            volunteer.UserId = appUser.Id;

        }

        public async Task<IActionResult> OnPost()
        {


            if (ModelState.IsValid)
            {

                _unitOfWork.volunteer.Add(volunteer);
                _unitOfWork.Save();
                return RedirectToPage("Confirmation");
            } 
            return Page();
        }
    }
}
