using Hotel_management.DAL;
using Hotel_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class RoomTypeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public RoomTypeController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public async Task<ActionResult> Index(int page = 1)
        {
            var query =  _context.RoomTypes.Where(r => r.IsDeleted == false).AsQueryable();
            IEnumerable<RoomType> types = await _context.RoomTypes.Where(r => r.IsDeleted == false).Include(r => r.Hotel).Where(h=>h.Hotel.isDeleted==false).Skip((page - 1) * 10).Take(10).OrderBy(r => r.HotelId).ThenBy(r => r.Hotel.Name).
                ToListAsync();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 10m);
            ViewBag.SelectPage = page;
            return View(types);
        }

        public async Task<IActionResult>Create()
        {
            ViewBag.Hotels = await _context.Hotels.Include(r => r.RoomTypes.Where(r=>r.IsDeleted==false)).Where(r=>r.isDeleted==false).ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomType type)
        {
            ViewBag.Hotels = await _context.Hotels.Include(r => r.RoomTypes.Where(r => r.IsDeleted == false)).Where(r => r.isDeleted == false).ToListAsync();



            if (!ModelState.IsValid)
                return View(type);


            var hotel = await _context.Hotels.Where(h=>h.isDeleted==false).Include(r=>r.RoomTypes.Where(r=>r.IsDeleted==false)).FirstOrDefaultAsync(r => r.Id == type.HotelId);

            if (hotel.RoomTypes != null)
            {
                foreach (var item in hotel.RoomTypes)
                {
                    if(type.Name.ToLower() == item.Name.ToLower())
                    {
                        ModelState.AddModelError("Name", "Otelde bu adda Roomtype artiq movcuddur");
                        return View(type);
                    }
                }
            };
            type.Hotel = hotel;
            await _context.RoomTypes.AddAsync(type);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
          
        }

        public async Task<IActionResult> Update(int? Id)
        {
            

            if (Id is null or 0)
                return NotFound();


            RoomType Roomtype = await _context.RoomTypes.FirstOrDefaultAsync(r => r.Id == Id);
            if (Roomtype == null)
                return BadRequest();
            Roomtype.Hotel =  _context.Hotels.FirstOrDefault(r=>r.Id==Roomtype.HotelId);
           
            return View(Roomtype);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? Id,RoomType type)
        {
            

            if (Id is null or 0)
                return NotFound();
            RoomType roomtype = await _context.RoomTypes.FirstOrDefaultAsync(r => r.Id == Id);
            if (roomtype == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return View(roomtype);
            }
           

            roomtype.Name = type.Name;
            roomtype.OneweekPrice = type.OneweekPrice;
            roomtype.TwoweeksPrice = type.TwoweeksPrice;
            roomtype.ThreeweeksPrice = type.ThreeweeksPrice;
            roomtype.OneweekPriceMid = type.OneweekPriceMid;
            roomtype.TwoweeksPriceMid = type.TwoweeksPriceMid;
            roomtype.ThreeweeksPriceMid = type.ThreeweeksPriceMid;
            roomtype.OneweekPriceHigh = type.OneweekPriceHigh;
            roomtype.TwoweeksPriceHigh = type.TwoweeksPriceHigh;
            roomtype.ThreeweeksPriceHigh = type.ThreeweeksPriceHigh;

            await _context.SaveChangesAsync();
           return RedirectToAction(nameof(Index));

        }



        public async Task<IActionResult>Delete(int? id)
        {
           if (id is null or 0)
                return NotFound();
            var type = await _context.RoomTypes.FirstOrDefaultAsync(r => r.Id == id);

            if (type == null)
                return BadRequest();

            type.IsDeleted = true;
            await _context.SaveChangesAsync();

           return  RedirectToAction(nameof(Index));    
          
        }


    }
}
