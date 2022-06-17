using Microsoft.AspNetCore.Mvc;
using Hotel_management.DAL;
using Microsoft.EntityFrameworkCore;
namespace Hotel_management.Controllers
{
    public class TransferController : Controller
    {
        private readonly AppDbContext _context;
        public TransferController(AppDbContext context)
        {

            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transfers.ToListAsync());
        }
    }
}
