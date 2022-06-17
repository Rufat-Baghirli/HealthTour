using Hotel_management.DAL;
using Hotel_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class LocationController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public LocationController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public async Task<IActionResult> Index()
        {
            IEnumerable <Location>locations = await _context.Locations.ToListAsync();
            return View(locations);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Location location)
        {
            if (await _context.Locations.AnyAsync(g => g.City.ToLower() == location.City.ToLower()))
            {
                ModelState.AddModelError("City", $" {location.City} Adda seher artiq movcuddur");
                return View(location);
            }

            await _context.AddAsync(location);
            await _context.SaveChangesAsync();
          return  RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            if (!await _context.Locations.AnyAsync(l => l.Id == id))
                return BadRequest();
            Location Location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);



            return View(Location);




        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Location location)
        {
     
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");



        }
    }
}
