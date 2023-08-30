using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Charity.DataAccess.Data;
using System.Linq;
using Charity.Models;
using Charity.DataAccess.Repository.IRepository;

namespace Charity.Pages.Admin.ProgramsTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;


        
        public ProgramType ProgramType{get; set; } 

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


        }

        public void OnGet(int id)
        {
            ProgramType = _unitOfWork.ProgramType.GetFirstOrDefault(m=>m.Id==id);
        }
        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = _unitOfWork.ProgramType.GetFirstOrDefault(s=> s.Id  == ProgramType.Id);
            if (categoryFromDb != null)
            {
                _unitOfWork.ProgramType.Remove(categoryFromDb);
                _unitOfWork.Save();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
