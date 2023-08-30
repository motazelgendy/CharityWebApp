using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Charity.DataAccess.Data;
using System.Linq;
using Charity.Models;
using Charity.DataAccess.Repository.IRepository;

namespace Charity.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
       

        public readonly IUnitOfWork _unitOfWork;

        public Category category { get; set; } 

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }

        public void OnGet(int id)
        {
            category = _unitOfWork.Category.GetFirstOrDefault(m=> m.Id==id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                 _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
