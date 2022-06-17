using Hotel_management.DAL;
using Hotel_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class ExtraPriceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ExtraPriceController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }



        public async Task<IActionResult> Index()
        {
            IEnumerable<ExtraPrice> Extraprice = await _context.ExtraPrices.Where(r=>r.IsDeleted == false && r.Hotel.isDeleted==false).
                Include(e=>e.Hotel).
                ToListAsync();
            return View(Extraprice);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Hotels = await _context.Hotels.Where(r => r.isDeleted == false).ToListAsync();




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExtraPrice extra)
        {
            ViewBag.Hotels = await _context.Hotels.Where(r => r.isDeleted == false).ToListAsync();



            extra.Hotel = await _context.Hotels.Include(r=>r.RoomTypes).FirstOrDefaultAsync(r => r.Id == extra.HotelId);
          

            await _context.ExtraPrices.AddAsync(extra);
            await _context.SaveChangesAsync();

           return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? Id)
        {
            ViewBag.Hotels = await _context.Hotels.Where(r => r.isDeleted == false).ToListAsync();


            if (Id == null|| Id==0)
                return NotFound();

            ExtraPrice Extraprice = await _context.ExtraPrices.Include(r=>r.Hotel).FirstOrDefaultAsync(e => e.Id == Id);

            if (Extraprice == null)
                return BadRequest();

            return View(Extraprice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? Id,ExtraPrice extraPrice)
        {
            ViewBag.Hotels = await _context.Hotels.Where(r => r.isDeleted == false).ToListAsync();


            if (Id == null || Id == 0)
                return NotFound();

            ExtraPrice dbPrice = await _context.ExtraPrices.Include(r => r.Hotel).Where(
                r=>r.Hotel.isDeleted == false).FirstOrDefaultAsync(e => e.Id == Id);
            if (dbPrice == null)
                return BadRequest();


            if (!ModelState.IsValid)
                return View(dbPrice);
            
            dbPrice.BabyPrice = extraPrice.BabyPrice;
            dbPrice.HotelId = extraPrice.HotelId;
            dbPrice.ChildPrice = extraPrice.ChildPrice;
            dbPrice.YoungPrice = extraPrice.YoungPrice;
       




            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult>Delete(int? Id)
        {
            if (Id == null || Id == 0)
                return NotFound();

            ExtraPrice Extraprice = await _context.ExtraPrices.FirstOrDefaultAsync(r => r.Id == Id);
            if (Extraprice == null)
                return BadRequest();
            Extraprice.IsDeleted = true;
            await _context.SaveChangesAsync();
         return  RedirectToAction(nameof(Index));

        }
    }
}
