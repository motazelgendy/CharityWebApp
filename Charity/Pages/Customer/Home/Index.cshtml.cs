using Charity.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Charity.Models;
using System.Linq;

namespace Charity.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;


        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ProgramItem> programItems { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public void OnGet(int? CatId = null)
        {
            if (CatId == null)
            {
                programItems = _unitOfWork.ProgramItem.GetAll(IncludeProperties: "Category,ProgramType");
                CategoryList = _unitOfWork.Category.GetAll();
            }
            else
            {
                programItems = _unitOfWork.ProgramItem.GetAll(IncludeProperties: "Category,ProgramType").Where(p => p.CategoryId == CatId);
				CategoryList = _unitOfWork.Category.GetAll();
			}
		}
        
    }
}
