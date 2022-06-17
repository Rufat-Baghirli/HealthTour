#nullable disable
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

    public class HotelTranslationsController : Controller
    {
        private readonly AppDbContext _context;

        public HotelTranslationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/HotelTranslations
        public async Task<IActionResult> Index()
        {
            var HotelTranslations = _context.HotelTranslations.Include(h => h.hotel);
            return View(await HotelTranslations.ToListAsync());
        }

        // GET: Manage/HotelTranslations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelTranslations = await _context.HotelTranslations
                .Include(h => h.hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelTranslations == null)
            {
                return NotFound();
            }

            return View(hotelTranslations);
        }

        // GET: Manage/HotelTranslations/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Description");
            return View();
        }

        // POST: Manage/HotelTranslations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description_en,Description_ru,HotelId")] HotelTranslations hotelTranslations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelTranslations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Description", hotelTranslations.HotelId);
            return View(hotelTranslations);
        }

        // GET: Manage/HotelTranslations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelTranslations = await _context.HotelTranslations.FindAsync(id);
            if (hotelTranslations == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Description", hotelTranslations.HotelId);
            return View(hotelTranslations);
        }

        // POST: Manage/HotelTranslations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description_en,Description_ru,HotelId")] HotelTranslations hotelTranslations)
        {
            if (id != hotelTranslations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelTranslations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelTranslationsExists(hotelTranslations.Id))
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
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Description", hotelTranslations.HotelId);
            return View(hotelTranslations);
        }

        // GET: Manage/HotelTranslations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelTranslations = await _context.HotelTranslations
                .Include(h => h.hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelTranslations == null)
            {
                return NotFound();
            }

            return View(hotelTranslations);
        }

        // POST: Manage/HotelTranslations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelTranslations = await _context.HotelTranslations.FindAsync(id);
            _context.HotelTranslations.Remove(hotelTranslations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelTranslationsExists(int id)
        {
            return _context.HotelTranslations.Any(e => e.Id == id);
        }
    }
}
