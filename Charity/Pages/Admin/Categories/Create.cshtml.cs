using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Charity.DataAccess.Data;
using Charity.Models;
using Charity.DataAccess.Repository.IRepository;

namespace Charity.Pages.Admin.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        
        public readonly IUnitOfWork _unitOfWork;

        public Category category { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                 _unitOfWork.Category.Add(category);
                 _unitOfWork.Save();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
