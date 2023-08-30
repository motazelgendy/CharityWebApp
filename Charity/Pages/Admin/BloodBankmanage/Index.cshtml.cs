using Charity.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Charity.Models;
using Charity.DataAccess.Repository;
using Charity.DataAccess.Repository.IRepository;
using Charity.Utility;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Charity.Pages.Admin.BloodBankmanage
{
    [Authorize(Roles = $"{UserRole.AdminRole}")]
    public class IndexModel : PageModel
    {

        public readonly IUnitOfWork _unitOfWork;

        public IEnumerable<BloodBank> bloodBanks { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            bloodBanks = _unitOfWork.BloodBank.GetAll();
        }
    }
}
