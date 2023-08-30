using Charity.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Charity.Pages.Admin.ProgramItems
{
    [Authorize(Roles = $"{UserRole.AdminRole}")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
