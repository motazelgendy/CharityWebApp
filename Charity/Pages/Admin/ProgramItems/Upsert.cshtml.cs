using Charity.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Charity.Models;
using Charity.DataAccess.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Charity.Pages.Admin.ProgramItems
{
    [BindProperties]
    public class UpsertModel : PageModel
    {



        public readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProgramItem ProgramItem { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> ProgramtypeList { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            ProgramItem = new();

        }

        public void OnGet(int? id)
        {
            if(id != null)
            {
                ProgramItem = _unitOfWork.ProgramItem.GetFirstOrDefault(s => s.Id == id);
            }
            CategoryList = _unitOfWork.Category.GetAll().Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.Id.ToString()

            });
            ProgramtypeList = _unitOfWork.ProgramType.GetAll().Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.Id.ToString()

            });
        }

        public async Task<IActionResult> OnPost()
        {


            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if(ProgramItem.Id ==0)
            {
                //this logic for create a new item :)

                string NewFileName = Guid.NewGuid().ToString();
                var Uploads = Path.Combine(webRootPath, @"imgs\items");
                var Extension = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(Uploads, NewFileName + Extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                ProgramItem.Image = @"\imgs\items\" + NewFileName + Extension;
                _unitOfWork.ProgramItem.Add(ProgramItem);
                _unitOfWork.Save();


            }

            else
            {
                //this logic for edite an item :)
                var objFromDb = _unitOfWork.ProgramItem.GetFirstOrDefault(u => u.Id == ProgramItem.Id);
                if (files.Count > 0)
                {
                    string fileName_new = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"imgs\items");
                    var extension = Path.GetExtension(files[0].FileName);

                    //delete the old image
                    var OldImagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
                    if (System.IO.File.Exists(OldImagePath))
                    {
                        System.IO.File.Delete(OldImagePath);
                    }
                    //new upload
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    ProgramItem.Image = @"\imgs\items\" + fileName_new + extension;
                }
                else
                {
                    ProgramItem.Image = objFromDb.Image;
                }
                _unitOfWork.ProgramItem.Update(ProgramItem);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }

    }
}


