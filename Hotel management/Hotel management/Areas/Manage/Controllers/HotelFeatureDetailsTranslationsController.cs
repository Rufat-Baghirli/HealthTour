using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_management.DAL;
using Hotel_management.Models;
using Microsoft.AspNetCore.Authorization;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]

    public class HotelFeatureDetailsTranslationsController : Controller
    {
        private readonly AppDbContext _context;

        public HotelFeatureDetailsTranslationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/HotelFeatureDetailsTranslations
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.HotelFeatureDetailsTranslations.Include(h => h.HotelFeatureDetails);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Manage/HotelFeatureDetailsTranslations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HotelFeatureDetailsTranslations == null)
            {
                return NotFound();
            }

            var hotelFeatureDetailsTranslations = await _context.HotelFeatureDetailsTranslations
                .Include(h => h.HotelFeatureDetails)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelFeatureDetailsTranslations == null)
            {
                return NotFound();
            }

            return View(hotelFeatureDetailsTranslations);
        }

        // GET: Manage/HotelFeatureDetailsTranslations/Create
        public IActionResult Create()
        {
            ViewData["HotelFeatureDetailsId"] = new SelectList(_context.HotelFeatureDetails, "Id", "Detail");
            return View();
        }

        // POST: Manage/HotelFeatureDetailsTranslations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Detail_en,Detail_ru,HotelFeatureDetailsId")] HotelFeatureDetailsTranslations hotelFeatureDetailsTranslations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelFeatureDetailsTranslations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelFeatureDetailsId"] = new SelectList(_context.HotelFeatureDetails, "Id", "Detail", hotelFeatureDetailsTranslations.HotelFeatureDetailsId);
            return View(hotelFeatureDetailsTranslations);
        }

        // GET: Manage/HotelFeatureDetailsTranslations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HotelFeatureDetailsTranslations == null)
            {
                return NotFound();
            }

            var hotelFeatureDetailsTranslations = await _context.HotelFeatureDetailsTranslations.FindAsync(id);
            if (hotelFeatureDetailsTranslations == null)
            {
                return NotFound();
            }
            ViewData["HotelFeatureDetailsId"] = new SelectList(_context.HotelFeatureDetails, "Id", "Detail", hotelFeatureDetailsTranslations.HotelFeatureDetailsId);
            return View(hotelFeatureDetailsTranslations);
        }

        // POST: Manage/HotelFeatureDetailsTranslations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Detail_en,Detail_ru,HotelFeatureDetailsId")] HotelFeatureDetailsTranslations hotelFeatureDetailsTranslations)
        {
            if (id != hotelFeatureDetailsTranslations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelFeatureDetailsTranslations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelFeatureDetailsTranslationsExists(hotelFeatureDetailsTranslations.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelFeatureDetailsId"] = new SelectList(_context.HotelFeatureDetails, "Id", "Detail", hotelFeatureDetailsTranslations.HotelFeatureDetailsId);
            return View(hotelFeatureDetailsTranslations);
        }

        // GET: Manage/HotelFeatureDetailsTranslations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HotelFeatureDetailsTranslations == null)
            {
                return NotFound();
            }

            var hotelFeatureDetailsTranslations = await _context.HotelFeatureDetailsTranslations
                .Include(h => h.HotelFeatureDetails)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelFeatureDetailsTranslations == null)
            {
                return NotFound();
            }

            return View(hotelFeatureDetailsTranslations);
        }

        // POST: Manage/HotelFeatureDetailsTranslations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HotelFeatureDetailsTranslations == null)
            {
                return Problem("Entity set 'AppDbContext.HotelFeatureDetailsTranslations'  is null.");
            }
            var hotelFeatureDetailsTranslations = await _context.HotelFeatureDetailsTranslations.FindAsync(id);
            if (hotelFeatureDetailsTranslations != null)
            {
                _context.HotelFeatureDetailsTranslations.Remove(hotelFeatureDetailsTranslations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelFeatureDetailsTranslationsExists(int id)
        {
          return (_context.HotelFeatureDetailsTranslations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
