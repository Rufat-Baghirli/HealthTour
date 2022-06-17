using Hotel_management.DAL;
using Hotel_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class HotelFeatureDetailsController : Controller
    {
        
  
            private readonly AppDbContext _context;
            private readonly IWebHostEnvironment _env;

            public HotelFeatureDetailsController(AppDbContext context, IWebHostEnvironment env)
            {
                _context = context;
                _env = env;

            }
            public async Task<ActionResult> Index()
            {
                IEnumerable<HotelFeatureDetails> details = await _context.HotelFeatureDetails.Include(h => h.HotelFeature).
                ThenInclude(h=>h.Hotel).ToListAsync();
                return View(details);
            }




        public async Task<ActionResult> Create()
        {
            ViewBag.Features = await _context.HotelFeatures.Include(h=>h.Hotel).ToListAsync();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HotelFeatureDetails feature)
        {
            ViewBag.Features = await _context.HotelFeatures.Include(h=>h.Hotel).ToListAsync();




            if (await _context.HotelFeatureDetails.Where(h => h.HotelFeatureId == feature.HotelFeatureId).AnyAsync(g => g.Detail.ToLower() == feature.Detail.ToLower()))
            {
                ModelState.AddModelError("Detail", $"{feature.Detail} Adda xususiyyet artiq movcuddur");
                return View(feature);
            }
            if (feature.HotelFeatureId != 0 && !await _context.HotelFeatures.AnyAsync(a => a.Id == feature.HotelFeatureId))
            {
                ModelState.AddModelError("Feature", "Feature Mutleq Secilmelidi");
                return View(feature);
            }

            await _context.HotelFeatureDetails.AddAsync(feature);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

       
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null || id == 0)
                    return NotFound();
                if (!await _context.HotelFeatureDetails.AnyAsync(l => l.Id == id))
                    return BadRequest();
                HotelFeatureDetails? hotelFeature = await _context.HotelFeatureDetails.Include(h=>h.HotelFeature).ThenInclude(h=>h.Hotel)
                .FirstOrDefaultAsync(l => l.Id == id);
            


                return View(hotelFeature);




            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(HotelFeatureDetails feature)
            {

                _context.HotelFeatureDetails.Remove(feature);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");



            }
        }
}
