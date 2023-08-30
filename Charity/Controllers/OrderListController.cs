using Microsoft.AspNetCore.Mvc;
using Charity.DataAccess.Repository.IRepository;

namespace Charity.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OrderListController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public OrderListController(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
          
       }
        [HttpGet]
       public IActionResult Get()
        {
            var OrderHeaderList = _unitOfWork.OrderHeader.GetAll(IncludeProperties: "AppUser");

            return Json(new {data = OrderHeaderList});
        }

       
    }
}
