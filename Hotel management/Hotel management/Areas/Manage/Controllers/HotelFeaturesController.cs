using Hotel_management.DAL;
using Hotel_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class HotelFeaturesController : Controller
    {
        
        

            private readonly AppDbContext _context;
            private readonly IWebHostEnvironment _env;

            public HotelFeaturesController(AppDbContext context, IWebHostEnvironment env)
            {
                _context = context;
                _env = env;

            }
            public async Task<ActionResult> Index()
        {
            IEnumerable<HotelFeature>features  = await _context.HotelFeatures.Where(r=>r.IsDeleted==false).Include(f=>f.Hotel).ToListAsync();
            return View(features);
        }

       
     
  
        public async Task<ActionResult> Create()
        {
            ViewBag.Hotels = await _context.Hotels.ToListAsync();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HotelFeature feature)
        {
            ViewBag.Hotels = await _context.Hotels.ToListAsync();



            if (await _context.HotelFeatures.Where(h=>h.HotelId==feature.HotelId).AnyAsync(g => g.Name.ToLower() == feature.Name.ToLower()))
            {
                ModelState.AddModelError("Name", $" {feature.Name} Adda xususiyyet artiq movcuddur");
                return View(feature);
            }
            if (feature.HotelId != 0 && !await _context.Hotels.AnyAsync(a => a.Id == feature.HotelId))
            {
                ModelState.AddModelError("HotelId", "Otel Mutleq Secilmelidi");
                return View(feature);
            }

            await _context.HotelFeatures.AddAsync(feature);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Hotels = await _context.Hotels.ToListAsync();

            if (id == null || id == 0)
                return NotFound();
            HotelFeature ft = await _context.HotelFeatures.FirstOrDefaultAsync(g => g.Id == id);
            if (ft == null)
                return BadRequest();

            return View(ft);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, HotelFeature hotelFeature)
        {
            ViewBag.Hotels = await _context.Hotels.ToListAsync();

            if (id == null || id == 0)
                return NotFound();

            HotelFeature dbfeature = await _context.HotelFeatures.FirstOrDefaultAsync(p => p.Id == id);

            if (dbfeature == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return View(hotelFeature);
            }
            if (await _context.HotelFeatures.AnyAsync(g => g.Name.ToLower() == hotelFeature.Name.ToLower()))
            {
                ModelState.AddModelError("Name", $" {hotelFeature.Name} Adda xususiyyet artiq movcuddur");
                return View(hotelFeature);
            }
            if (hotelFeature.HotelId != null && !await _context.Hotels.AnyAsync(a => a.Id == hotelFeature.HotelId))
            {
                ModelState.AddModelError("HotelId", "Otel Mutleq Secilmelidi");
                return View(hotelFeature);
            }
            dbfeature.Hotel = hotelFeature.Hotel;
            dbfeature.Name = hotelFeature.Name;
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {

            if (id is null or 0)
                return NotFound();
            HotelFeature feature = await _context.HotelFeatures.Where(n => n.IsDeleted == false).FirstOrDefaultAsync(n => n.Id == id);


            if (feature == null)
                return BadRequest();
           



            feature.IsDeleted = true;


            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
    }
}
