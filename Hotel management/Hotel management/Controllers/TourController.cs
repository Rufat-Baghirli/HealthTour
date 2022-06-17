using Hotel_management.DAL;
using Hotel_management.ViewModels.TourViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Controllers
{
    public class TourController : Controller
    {
        private readonly AppDbContext _context;

        public TourController(AppDbContext context)
        {

            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            TourVM vm = new TourVM
            {
                Tours = await _context.Tours.Where(t => t.IsDeleted == false).Include(t=>t.TourTranslations).ToListAsync(),
                foreignDomesticTour = await _context.ForeignDomesticTours.Include(f=>f.ForeignDomesticTourTanslations).FirstOrDefaultAsync(),
                TurContact = await _context.TurContacts.FirstOrDefaultAsync(),
                xariciTurlar = await _context.XariciTurlar.ToListAsync(),
                daxiliTurlar = await _context.DaxiliTurlar.ToListAsync()
            };
            return View(vm);
        }
    }
}
