using Hotel_management.DAL;
using Hotel_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class RoomFeatureDetailsController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public RoomFeatureDetailsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public async Task<ActionResult> Index()
        {
            IEnumerable<RoomFeatureDetail> details = await _context.RoomFeatureDetails.Include(h => h.RoomFeatures).
            ThenInclude(h => h.Room).ThenInclude(r=>r.RoomType).Include(h => h.RoomFeatures).
            ThenInclude(h => h.Room).ThenInclude(r => r.Hotel).ToListAsync();
            return View(details);
        }




        public async Task<ActionResult> Create()
        {
            ViewBag.Features = await _context.RoomFeatures.Include(h => h.Room).ThenInclude(r=>r.RoomType).Include(r=>r.Room).
                ThenInclude(r=>r.Hotel)
                .ToListAsync();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoomFeatureDetail feature)
        {
            ViewBag.Features = await _context.RoomFeatures.Include(h => h.Room).ThenInclude(r => r.RoomType).Include(r => r.Room).
                  ThenInclude(r => r.Hotel)
                  .ToListAsync();




            if (await _context.RoomFeatureDetails.Where(h => h.RoomFeaturesId == feature.RoomFeaturesId).AnyAsync(g => g.Detail.ToLower() == feature.Detail.ToLower()))
            {
                ModelState.AddModelError("Detail", $"{feature.Detail} Adda xususiyyet artiq movcuddur");
                return View(feature);
            }
            if (feature.RoomFeaturesId != 0 && !await _context.RoomFeatures.AnyAsync(a => a.Id == feature.RoomFeaturesId))
            {
                ModelState.AddModelError("RoomFeaturesId", "Feature Mutleq Secilmelidi");
                return View(feature);
            }

            await _context.RoomFeatureDetails.AddAsync(feature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            if (!await _context.RoomFeatureDetails.AnyAsync(l => l.Id == id))
                return BadRequest();
            RoomFeatureDetail? roomFeatureDetail = await _context.RoomFeatureDetails
            .FirstOrDefaultAsync(l => l.Id == id);



            return View(roomFeatureDetail);




        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RoomFeatureDetail feature)
        {

            _context.RoomFeatureDetails.Remove(feature);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));



        }
    }
}
