using Microsoft.AspNetCore.Mvc;
using Hotel_management.DAL;
using Hotel_management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Hotel_management.ViewModels.HotelViewModel;

namespace Hotel_management.Controllers
{
    public class HotelController : Controller
    {
        private readonly AppDbContext _context;

        private readonly UserManager<AppUser> _usermanager;


        public HotelController(AppDbContext context, UserManager<AppUser> usermanager)
        {
            _usermanager = usermanager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HotelVM vm = new HotelVM
            {
                Hotels = await _context.Hotels.Where(h => h.isDeleted == false).Include(h => h.Location).Include(h => h.ExtraPrice).Include(h => h.HotelFeatures).ThenInclude(h=>h.HotelFeatureTranslations).Include(h => h.HotelFeatures).ThenInclude(h => h.HotelFeatureDetails).
                ThenInclude(h=>h.hotelFeatureDetailsTranslations).
                         Include(h => h.HotelImages).Include(h => h.HotelStar).Include(h => h.Reviews).Include(h => h.RoomTypes.Where(r => r.IsDeleted == false)).
                         Include(h => h.Treatments)
                         .Include(t=>t.hotelTranslations)
                         .ToListAsync(),


            };
          

            return View(vm);
        }

        public async Task<IActionResult> HotelDetails(int? Id)
        {
            if (Id == null)
                return NotFound();

            Hotel hotel = await _context.Hotels.Where(h => h.isDeleted == false).
               Include(h => h.Location).
               Include(h => h.ExtraPrice).
              Include(h => h.HotelFeatures).ThenInclude(h => h.HotelFeatureTranslations).Include(h => h.HotelFeatures).ThenInclude(h => h.HotelFeatureDetails).
                ThenInclude(h => h.hotelFeatureDetailsTranslations).
               Include(h => h.HotelImages).
               Include(h => h.HotelStar).
               Include(h => h.Reviews).
               Include(h => h.RoomTypes.Where(r => r.IsDeleted == false)).
               Include(h => h.Treatments).
               Include(t => t.hotelTranslations).
               Include(r=>r.Rooms.Where(r=>r.isDeleted==false)).
               ThenInclude(r => r.RoomImages)
              .Include(r => r.Rooms).
               ThenInclude(r => r.RoomType).
               Include(r=>r.Rooms).
              ThenInclude(r => r.RoomFeatures).
              ThenInclude(f => f.RoomFeaturesTranslation).
              Include(r => r.Rooms).
              ThenInclude(r => r.RoomFeatures).
              ThenInclude(f => f.RoomFeatureDetails).
              ThenInclude(f => f.RoomFeatureDetailTranslations).
              FirstOrDefaultAsync(h=>h.Id == Id);

            if (hotel == null)
                return NotFound();
            HotelVM vm = new HotelVM
            {
                Hotel = hotel
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendComment(int Id, HotelVM riview)
        {
            Review comment = new Review
            {
                HotelId = Id,
                Email = riview.Reviews.Email,
                Text = riview.Reviews.Text,
                UserName = riview.Reviews.UserName,
                Date = DateTime.UtcNow.AddHours(+4)
            };
            comment.AppUserId = (User.Identity.IsAuthenticated) ? (await _usermanager.FindByNameAsync(User.Identity.Name)).Id : null;
            await _context.Reviews.AddAsync(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
