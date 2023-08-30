using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Charity.DataAccess.Data;
using System.Linq;
using Charity.Models;
using Charity.DataAccess.Repository.IRepository;


namespace Charity.Pages.Admin.BloodBankmanage
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        

        public readonly IUnitOfWork _unitOfWork;

        public BloodBank bloodbank { get; set; } 

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }

        public void OnGet(int id)
        {
            bloodbank = _unitOfWork.BloodBank.GetFirstOrDefault(m=>m.Id==id);
        }
        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = _unitOfWork.BloodBank.GetFirstOrDefault(s=>s.Id==bloodbank.Id);
            if (categoryFromDb != null)
            {
                _unitOfWork.BloodBank.Remove(categoryFromDb);
                _unitOfWork.Save();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
