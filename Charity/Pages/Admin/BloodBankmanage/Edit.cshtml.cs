using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Charity.DataAccess.Data;
using System.Linq;
using Charity.Models;
using Charity.DataAccess.Repository.IRepository;

namespace Charity.Pages.Admin.BloodBankmanage
{
    [BindProperties]
    public class EditModel : PageModel
    {
       

        public readonly IUnitOfWork _unitOfWork;

        public BloodBank bloodBank { get; set; } 

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }

        public void OnGet(int id)
        {
            bloodBank = _unitOfWork.BloodBank.GetFirstOrDefault(m=> m.Id==id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                 _unitOfWork.BloodBank.Update(bloodBank);
                _unitOfWork.Save();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
