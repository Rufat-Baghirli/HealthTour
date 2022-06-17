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

    public class HotelFeatureTranslationsController : Controller
    {
        private readonly AppDbContext _context;

        public HotelFeatureTranslationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/HotelFeatureTranslations
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.HotelFeatureTranslations.Include(h => h.HotelFeature);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Manage/HotelFeatureTranslations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HotelFeatureTranslations == null)
            {
                return NotFound();
            }

            var hotelFeatureTranslations = await _context.HotelFeatureTranslations
                .Include(h => h.HotelFeature)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelFeatureTranslations == null)
            {
                return NotFound();
            }

            return View(hotelFeatureTranslations);
        }

        // GET: Manage/HotelFeatureTranslations/Create
        public IActionResult Create()
        {
            ViewData["HotelFeatureId"] = new SelectList(_context.HotelFeatures, "Id", "Name");
            return View();
        }

        // POST: Manage/HotelFeatureTranslations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name_en,Name_ru,HotelFeatureId")] HotelFeatureTranslations hotelFeatureTranslations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelFeatureTranslations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelFeatureId"] = new SelectList(_context.HotelFeatures, "Id", "Name", hotelFeatureTranslations.HotelFeatureId);
            return View(hotelFeatureTranslations);
        }

        // GET: Manage/HotelFeatureTranslations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HotelFeatureTranslations == null)
            {
                return NotFound();
            }

            var hotelFeatureTranslations = await _context.HotelFeatureTranslations.FindAsync(id);
            if (hotelFeatureTranslations == null)
            {
                return NotFound();
            }
            ViewData["HotelFeatureId"] = new SelectList(_context.HotelFeatures, "Id", "Name", hotelFeatureTranslations.HotelFeatureId);
            return View(hotelFeatureTranslations);
        }

        // POST: Manage/HotelFeatureTranslations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name_en,Name_ru,HotelFeatureId")] HotelFeatureTranslations hotelFeatureTranslations)
        {
            if (id != hotelFeatureTranslations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelFeatureTranslations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelFeatureTranslationsExists(hotelFeatureTranslations.Id))
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
            ViewData["HotelFeatureId"] = new SelectList(_context.HotelFeatures, "Id", "Name", hotelFeatureTranslations.HotelFeatureId);
            return View(hotelFeatureTranslations);
        }

        // GET: Manage/HotelFeatureTranslations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HotelFeatureTranslations == null)
            {
                return NotFound();
            }

            var hotelFeatureTranslations = await _context.HotelFeatureTranslations
                .Include(h => h.HotelFeature)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelFeatureTranslations == null)
            {
                return NotFound();
            }

            return View(hotelFeatureTranslations);
        }

        // POST: Manage/HotelFeatureTranslations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HotelFeatureTranslations == null)
            {
                return Problem("Entity set 'AppDbContext.HotelFeatureTranslations'  is null.");
            }
            var hotelFeatureTranslations = await _context.HotelFeatureTranslations.FindAsync(id);
            if (hotelFeatureTranslations != null)
            {
                _context.HotelFeatureTranslations.Remove(hotelFeatureTranslations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelFeatureTranslationsExists(int id)
        {
          return (_context.HotelFeatureTranslations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
