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

    public class RoomFeatureDetailTranslationsController : Controller
    {
        private readonly AppDbContext _context;

        public RoomFeatureDetailTranslationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/RoomFeatureDetailTranslations
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.RoomFeatureDetailTranslations.Include(r => r.RoomFeatureDetail);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Manage/RoomFeatureDetailTranslations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoomFeatureDetailTranslations == null)
            {
                return NotFound();
            }

            var roomFeatureDetailTranslations = await _context.RoomFeatureDetailTranslations
                .Include(r => r.RoomFeatureDetail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomFeatureDetailTranslations == null)
            {
                return NotFound();
            }

            return View(roomFeatureDetailTranslations);
        }

        // GET: Manage/RoomFeatureDetailTranslations/Create
        public IActionResult Create()
        {
            ViewData["RoomFeatureDetailId"] = new SelectList(_context.RoomFeatureDetails, "Id", "Detail");
            return View();
        }

        // POST: Manage/RoomFeatureDetailTranslations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Detail_en,Detail_ru,RoomFeatureDetailId")] RoomFeatureDetailTranslations roomFeatureDetailTranslations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomFeatureDetailTranslations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomFeatureDetailId"] = new SelectList(_context.RoomFeatureDetails, "Id", "Detail", roomFeatureDetailTranslations.RoomFeatureDetailId);
            return View(roomFeatureDetailTranslations);
        }

        // GET: Manage/RoomFeatureDetailTranslations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoomFeatureDetailTranslations == null)
            {
                return NotFound();
            }

            var roomFeatureDetailTranslations = await _context.RoomFeatureDetailTranslations.FindAsync(id);
            if (roomFeatureDetailTranslations == null)
            {
                return NotFound();
            }
            ViewData["RoomFeatureDetailId"] = new SelectList(_context.RoomFeatureDetails, "Id", "Detail", roomFeatureDetailTranslations.RoomFeatureDetailId);
            return View(roomFeatureDetailTranslations);
        }

        // POST: Manage/RoomFeatureDetailTranslations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Detail_en,Detail_ru,RoomFeatureDetailId")] RoomFeatureDetailTranslations roomFeatureDetailTranslations)
        {
            if (id != roomFeatureDetailTranslations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomFeatureDetailTranslations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomFeatureDetailTranslationsExists(roomFeatureDetailTranslations.Id))
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
            ViewData["RoomFeatureDetailId"] = new SelectList(_context.RoomFeatureDetails, "Id", "Detail", roomFeatureDetailTranslations.RoomFeatureDetailId);
            return View(roomFeatureDetailTranslations);
        }

        // GET: Manage/RoomFeatureDetailTranslations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoomFeatureDetailTranslations == null)
            {
                return NotFound();
            }

            var roomFeatureDetailTranslations = await _context.RoomFeatureDetailTranslations
                .Include(r => r.RoomFeatureDetail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomFeatureDetailTranslations == null)
            {
                return NotFound();
            }

            return View(roomFeatureDetailTranslations);
        }

        // POST: Manage/RoomFeatureDetailTranslations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomFeatureDetailTranslations == null)
            {
                return Problem("Entity set 'AppDbContext.RoomFeatureDetailTranslations'  is null.");
            }
            var roomFeatureDetailTranslations = await _context.RoomFeatureDetailTranslations.FindAsync(id);
            if (roomFeatureDetailTranslations != null)
            {
                _context.RoomFeatureDetailTranslations.Remove(roomFeatureDetailTranslations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomFeatureDetailTranslationsExists(int id)
        {
          return (_context.RoomFeatureDetailTranslations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
