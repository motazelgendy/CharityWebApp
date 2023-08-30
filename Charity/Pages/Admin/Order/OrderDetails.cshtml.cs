using Charity.DataAccess.Repository.IRepository;
using Charity.Models;
using Charity.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charity.Pages.Admin.Order
{
    public class OrderDetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailViewModel OrderDetailVM { get; set; }

        public OrderDetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            OrderDetailVM = new()
            {
                OrderHeader = _unitOfWork.OrderHeader.GetFirstOrDefault(u => u.Id == id, IncludeProperties: "AppUser"),
                OrderDetails = _unitOfWork.OrderDetails.GetAll(filter:m => m.OrderId == id).ToList()
            };
        }
    }
}
