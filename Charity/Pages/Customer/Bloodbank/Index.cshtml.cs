using Charity.DataAccess.Data;
using Charity.DataAccess.Repository.IRepository;
using Charity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Charity.Pages.Customer.Bloodbank
{
    public class IndexModel : PageModel
    {


        public readonly IUnitOfWork _unitOfWork;

        public readonly ApplicationDbContext applicationDbContext;

        public IEnumerable<BloodBank> bloodBanks { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task <IActionResult> OnGet()
        {
             await applicationDbContext.bloodBanks.ToListAsync();

            return Page();
        }

    }    
}
