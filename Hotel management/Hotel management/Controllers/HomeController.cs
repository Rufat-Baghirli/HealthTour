using Hotel_management.DAL;
//using Hotel_management.Resources;
using Hotel_management.ViewModels.HomeViewModel;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Hotel_management.Controllers
{

    public class HomeController : Controller
    {
 
        private readonly AppDbContext _context;
        private readonly IStringLocalizer<SharedResource> _localizer;


        public HomeController(AppDbContext context,IStringLocalizer<SharedResource> localizer)
        {

            _context = context;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index()
        {
            
            HomeVM homeVM = new HomeVM
            {
                Hotels = await _context.Hotels.Where(h=>h.isDeleted==false).
                Include(l => l.Location).
                Include(r => r.Rooms.Where(r=>r.isDeleted==false)).
                Include(h => h.HotelImages).
                Include(h => h.HotelStar).
                Include(h => h.hotelTranslations).
                ToListAsync(),
              


            };

            return View(homeVM);

        }
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        [Route("/Error")]
        public IActionResult Error()
        {
            return View();
        }

    }
}
