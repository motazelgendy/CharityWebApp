using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Charity.DataAccess.Data;
using System.Linq;
using Charity.Models;
using Charity.DataAccess.Repository.IRepository;
namespace Charity.Pages.Admin.ProgramsTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;




        public ProgramType ProgramType { get; set; } 

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }

        public void OnGet(int id)
        {
            ProgramType = _unitOfWork.ProgramType.GetFirstOrDefault(S=> S.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProgramType.Update(ProgramType);
                _unitOfWork.Save();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
