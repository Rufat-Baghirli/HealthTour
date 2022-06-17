using Hotel_management.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context) 
        { 

            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _context.AboutImages.ToListAsync());
        }
    }
}
