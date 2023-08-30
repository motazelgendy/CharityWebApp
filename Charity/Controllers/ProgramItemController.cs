using Microsoft.AspNetCore.Mvc;
using Charity.DataAccess.Repository.IRepository;

namespace Charity.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProgramItemController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProgramItemController (IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
           _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
       }
        [HttpGet]
       public IActionResult Get()
        {
            var ProgramItemList = _unitOfWork.ProgramItem.GetAll(IncludeProperties: "Category,ProgramType");

            return Json(new {data = ProgramItemList});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ObjfromDb = _unitOfWork.ProgramItem.GetFirstOrDefault(m => m.Id == id);
            var OldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, ObjfromDb.Image.TrimStart('\\'));
            if (System.IO.File.Exists(OldImagePath))
            {
                System.IO.File.Delete(OldImagePath);
            }
            _unitOfWork.ProgramItem.Remove(ObjfromDb);
            _unitOfWork.Save();
            
            return Json(new { success = true, message = "Delete Successful." });
        }
    }
}
