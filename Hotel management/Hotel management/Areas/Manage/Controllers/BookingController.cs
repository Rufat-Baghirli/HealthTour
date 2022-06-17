using Hotel_management.DAL;
using Hotel_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BookingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Bookings.Where(b=>b.IsDeleted==false).Include(b=>b.Adults).ThenInclude(t=>t.Treatment_model).Include(b=>b.Children).ThenInclude(t => t.Treatment_model).Include(h=>h.Hotel).ThenInclude(r=>r.Rooms).
                ThenInclude(r=>r.RoomType).ToListAsync());
        }

        public async Task<IActionResult> ChangeStatus(int? Id)
        {
            if (Id == null) return NotFound();

            Booking booking = await _context.Bookings.FirstOrDefaultAsync(b=>b.Id==Id);

            if (booking == null) return NotFound();

            booking.IsDeleted = true;


            if (booking.Adults != null)
            {
                _context.Adults.RemoveRange(booking.Adults);


            }
            if (booking.Children != null)
            {
                _context.Children.RemoveRange(booking.Children);

            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
