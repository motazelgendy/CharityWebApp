using Charity.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Charity.Controllers
{
    public class BloodbanksController : Controller
    {

        private readonly ApplicationDbContext _context;

        public BloodbanksController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.bloodBanks != null ?
                          View(await _context.bloodBanks.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.bloodbanks'  is null.");
        }
    }
}
