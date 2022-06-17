using Hotel_management.DAL;
using Hotel_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class RoomFeaturesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public RoomFeaturesController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public async Task<ActionResult> Index()
        {
            IEnumerable<RoomFeatures> features = await _context.RoomFeatures.
                Include(f => f.Room).ThenInclude(r=>r.RoomType).
                Include(f => f.Room).ThenInclude(r=>r.Hotel).
                ToListAsync();
            return View(features);
        }




        public async Task<ActionResult> Create()
        {
            ViewBag.Rooms = await _context.Rooms.Include(r => r.Hotel).Include(r => r.RoomType).ToListAsync();



            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoomFeatures feature)
        {
            ViewBag.Rooms = await _context.Rooms.Include(r=>r.Hotel).Include(r=>r.RoomType).ToListAsync();



            if (await _context.RoomFeatures.Where(h => h.RoomId == feature.RoomId).AnyAsync(g => g.Features.ToLower() == feature.Features.ToLower()))
            {
                ModelState.AddModelError("Features", $" {feature.Features} Adda xususiyyet artiq movcuddur");
                return View(feature);
            }
            if (feature.RoomId != 0 && !await _context.Rooms.AnyAsync(a => a.Id == feature.RoomId))
            {
                ModelState.AddModelError("HotelId", "Otel Mutleq Secilmelidi");
                return View(feature);
            }

            //feature.RoomFeatureDetails = null;

            await _context.RoomFeatures.AddAsync(feature);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Rooms = await _context.Rooms.Include(r=>r.Hotel).Include(r=>r.RoomType).ToListAsync();

            if (id == null || id == 0)
                return NotFound();
            RoomFeatures ft = await _context.RoomFeatures.
                Include(r=>r.Room).ThenInclude(r=>r.RoomType).
                  Include(r => r.Room).ThenInclude(r => r.Hotel)
                .FirstOrDefaultAsync(g => g.Id == id);
            if (ft == null)
                return BadRequest();

            return View(ft);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, RoomFeatures feature)
        {
            ViewBag.Rooms = await _context.Rooms.Include(r => r.Hotel).Include(r => r.RoomType).ToListAsync();


            if (id == null || id == 0)
                return NotFound();

            RoomFeatures dbfeature = await _context.RoomFeatures.
                Include(r => r.Room).ThenInclude(r => r.RoomType).
                  Include(r => r.Room).ThenInclude(r => r.Hotel)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (dbfeature == null)
                return BadRequest();

            //if (!ModelState.IsValid)
            //{
            //    return View(dbfeature);
            //}
            if (await _context.RoomFeatures.AnyAsync(g => g.Features.ToLower() == feature.Features.ToLower()))
            {
                ModelState.AddModelError("Features", $" {feature.Features} Adda xususiyyet artiq movcuddur");
                return View(feature);
            }
            if (feature.RoomId != 0 && !await _context.Rooms.AnyAsync(a => a.Id == feature.RoomId))
            {
                ModelState.AddModelError("RoomId", "Otaq Mutleq Secilmelidi");
                return View(feature);
            }
            dbfeature.RoomId = feature.RoomId;
            dbfeature.Features = feature.Features;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            if (!await _context.RoomFeatures.AnyAsync(l => l.Id == id))
                return BadRequest();
            RoomFeatures? roomFeature = await _context.RoomFeatures.
                Include(f => f.RoomFeatureDetails).Include(r=>r.Room).ThenInclude(r=>r.RoomType).
                Include(r=>r.Room).ThenInclude(r=>r.Hotel)
                .FirstOrDefaultAsync(l => l.Id == id);

           if( roomFeature==null)
           return NotFound();


            return View(roomFeature);




        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RoomFeatures feature)
        {
            if (feature.RoomFeatureDetails != null)
            {
                _context.RoomFeatureDetails.RemoveRange(feature.RoomFeatureDetails);

            }
            _context.RoomFeatures.Remove(feature);
          
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");



        }
    }
    }


