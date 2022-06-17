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

    public class TourTranslationsController : Controller
    {
        private readonly AppDbContext _context;

        public TourTranslationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/TourTranslations
        public async Task<IActionResult> Index()
        {
            IEnumerable<TourTranslations> Tours = await _context.TourTranslations.Include(t=>t.Tour).Where(t=>t.Tour.IsDeleted==false).ToListAsync();
            return View(Tours);
        }

        // GET: Manage/TourTranslations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TourTranslations == null)
            {
                return NotFound();
            }

            var tourTranslations = await _context.TourTranslations
                .Include(t => t.Tour)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tourTranslations == null)
            {
                return NotFound();
            }

            return View(tourTranslations);
        }

        // GET: Manage/TourTranslations/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Tours = await _context.Tours.Where(t => t.IsDeleted == false).ToListAsync();
            return View();
        }

        // POST: Manage/TourTranslations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name_en,Name_ru,Description_en,Description_ru,TourId")] TourTranslations tourTranslations)
        {
            ViewBag.Tours = await _context.Tours.Where(t => t.IsDeleted == false).ToListAsync();
           
            if (ModelState.IsValid)
            {

                _context.Add(tourTranslations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
           
            return View(tourTranslations);
        }

        // GET: Manage/TourTranslations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TourTranslations == null)
            {
                return NotFound();
            }

            var tourTranslations = await _context.TourTranslations.FindAsync(id);
            if (tourTranslations == null)
            {
                return NotFound();
            }
            ViewData["TourId"] = new SelectList(_context.Tours, "Id", "Description", tourTranslations.TourId);
            return View(tourTranslations);
        }

        // POST: Manage/TourTranslations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name_en,Name_ru,Description_en,Description_ru,TourId")] TourTranslations tourTranslations)
        {
            if (id != tourTranslations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tourTranslations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourTranslationsExists(tourTranslations.Id))
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
            ViewData["TourId"] = new SelectList(_context.Tours, "Id", "Description", tourTranslations.TourId);
            return View(tourTranslations);
        }

        // GET: Manage/TourTranslations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TourTranslations == null)
            {
                return NotFound();
            }

            var tourTranslations = await _context.TourTranslations
                .Include(t => t.Tour)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tourTranslations == null)
            {
                return NotFound();
            }

            return View(tourTranslations);
        }

        // POST: Manage/TourTranslations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TourTranslations == null)
            {
                return Problem("Entity set 'AppDbContext.TourTranslations'  is null.");
            }
            var tourTranslations = await _context.TourTranslations.FindAsync(id);
            if (tourTranslations != null)
            {
                _context.TourTranslations.Remove(tourTranslations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourTranslationsExists(int id)
        {
          return (_context.TourTranslations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
