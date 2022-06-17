using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_management.DAL;
using Hotel_management.Models;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SeasonsController : Controller
    {
        private readonly AppDbContext _context;

        public SeasonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/Seasons
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Seasons.Include(s => s.Hotel);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Manage/Seasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Seasons == null)
            {
                return NotFound();
            }

            var seasons = await _context.Seasons
                .Include(s => s.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seasons == null)
            {
                return NotFound();
            }

            return View(seasons);
        }

        // GET: Manage/Seasons/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Name");
            return View();
        }

        // POST: Manage/Seasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HotelId")] Seasons seasons)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seasons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Name", seasons.HotelId);
            return View(seasons);
        }

        // GET: Manage/Seasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Seasons == null)
            {
                return NotFound();
            }

            var seasons = await _context.Seasons.FindAsync(id);
            if (seasons == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Name", seasons.HotelId);
            return View(seasons);
        }

        // POST: Manage/Seasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HotelId")] Seasons seasons)
        {
            if (id != seasons.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seasons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeasonsExists(seasons.Id))
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
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Name", seasons.HotelId);
            return View(seasons);
        }

        // GET: Manage/Seasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Seasons == null)
            {
                return NotFound();
            }

            var seasons = await _context.Seasons
                .Include(s => s.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seasons == null)
            {
                return NotFound();
            }

            return View(seasons);
        }

        // POST: Manage/Seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Seasons == null)
            {
                return Problem("Entity set 'AppDbContext.Seasons'  is null.");
            }
            var seasons = await _context.Seasons.FindAsync(id);
            if (seasons != null)
            {
                _context.Seasons.Remove(seasons);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeasonsExists(int id)
        {
          return (_context.Seasons?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
