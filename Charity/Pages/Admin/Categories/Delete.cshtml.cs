using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Charity.DataAccess.Data;
using System.Linq;
using Charity.Models;
using Charity.DataAccess.Repository.IRepository;
namespace Charity.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        

        public readonly IUnitOfWork _unitOfWork;

        public Category category { get; set; } 

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }

        public void OnGet(int id)
        {
            category = _unitOfWork.Category.GetFirstOrDefault(m=>m.Id==id);
        }
        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(s=>s.Id==category.Id);
            if (categoryFromDb != null)
            {
                _unitOfWork.Category.Remove(categoryFromDb);
                _unitOfWork.Save();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
