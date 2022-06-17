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

    public class RoomFeaturesTranslationsController : Controller
    {
        private readonly AppDbContext _context;

        public RoomFeaturesTranslationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/RoomFeaturesTranslations
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.RoomFeaturesTranslation.Include(r => r.RoomFeatures);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Manage/RoomFeaturesTranslations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoomFeaturesTranslation == null)
            {
                return NotFound();
            }

            var roomFeaturesTranslation = await _context.RoomFeaturesTranslation
                .Include(r => r.RoomFeatures)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomFeaturesTranslation == null)
            {
                return NotFound();
            }

            return View(roomFeaturesTranslation);
        }

        // GET: Manage/RoomFeaturesTranslations/Create
        public IActionResult Create()
        {
            ViewData["RoomFeaturesId"] = new SelectList(_context.RoomFeatures, "Id", "Features");
            return View();
        }

        // POST: Manage/RoomFeaturesTranslations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Features_en,Features_ru,RoomFeaturesId")] RoomFeaturesTranslation roomFeaturesTranslation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomFeaturesTranslation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomFeaturesId"] = new SelectList(_context.RoomFeatures, "Id", "Features", roomFeaturesTranslation.RoomFeaturesId);
            return View(roomFeaturesTranslation);
        }

        // GET: Manage/RoomFeaturesTranslations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoomFeaturesTranslation == null)
            {
                return NotFound();
            }

            var roomFeaturesTranslation = await _context.RoomFeaturesTranslation.FindAsync(id);
            if (roomFeaturesTranslation == null)
            {
                return NotFound();
            }
            ViewData["RoomFeaturesId"] = new SelectList(_context.RoomFeatures, "Id", "Features", roomFeaturesTranslation.RoomFeaturesId);
            return View(roomFeaturesTranslation);
        }

        // POST: Manage/RoomFeaturesTranslations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Features_en,Features_ru,RoomFeaturesId")] RoomFeaturesTranslation roomFeaturesTranslation)
        {
            if (id != roomFeaturesTranslation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomFeaturesTranslation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomFeaturesTranslationExists(roomFeaturesTranslation.Id))
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
            ViewData["RoomFeaturesId"] = new SelectList(_context.RoomFeatures, "Id", "Features", roomFeaturesTranslation.RoomFeaturesId);
            return View(roomFeaturesTranslation);
        }

        // GET: Manage/RoomFeaturesTranslations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoomFeaturesTranslation == null)
            {
                return NotFound();
            }

            var roomFeaturesTranslation = await _context.RoomFeaturesTranslation
                .Include(r => r.RoomFeatures)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomFeaturesTranslation == null)
            {
                return NotFound();
            }

            return View(roomFeaturesTranslation);
        }

        // POST: Manage/RoomFeaturesTranslations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomFeaturesTranslation == null)
            {
                return Problem("Entity set 'AppDbContext.RoomFeaturesTranslation'  is null.");
            }
            var roomFeaturesTranslation = await _context.RoomFeaturesTranslation.FindAsync(id);
            if (roomFeaturesTranslation != null)
            {
                _context.RoomFeaturesTranslation.Remove(roomFeaturesTranslation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomFeaturesTranslationExists(int id)
        {
          return (_context.RoomFeaturesTranslation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
