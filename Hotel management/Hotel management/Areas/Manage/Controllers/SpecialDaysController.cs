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
    public class SpecialDaysController : Controller
    {
        private readonly AppDbContext _context;

        public SpecialDaysController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/SpecialDays
        public async Task<IActionResult> Index()
        {
            var SpecialDays = _context.SpecialDays.Include(s => s.RoomType).ThenInclude(h=>h.Hotel);
            return View(await SpecialDays.ToListAsync());
        }

        // GET: Manage/SpecialDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SpecialDays == null)
            {
                return NotFound();
            }

            var specialDays = await _context.SpecialDays
                .Include(s => s.RoomType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialDays == null)
            {
                return NotFound();
            }

            return View(specialDays);
        }

        // GET: Manage/SpecialDays/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.RoomTypes = await _context.RoomTypes.Include(h=>h.Hotel).ToListAsync();
            return View();
        }

        // POST: Manage/SpecialDays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,RoomTypeId,Start,End")] SpecialDays specialDays)
        {
            ViewBag.RoomTypes = await _context.RoomTypes.Include(h => h.Hotel).ToListAsync();

            if (specialDays.Start > specialDays.End)
            {
                ModelState.AddModelError("Start", "Start Endden boyuk ola bilmez");
                return View(specialDays);
            }
            if (ModelState.IsValid)
            {
                _context.Add(specialDays);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(specialDays);
        }

        // GET: Manage/SpecialDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SpecialDays == null)
            {
                return NotFound();
            }

            var specialDays = await _context.SpecialDays.FindAsync(id);
            if (specialDays == null)
            {
                return NotFound();
            }
            ViewBag.RoomTypes = await _context.RoomTypes.Include(h => h.Hotel).ToListAsync();

            return View(specialDays);
        }

        // POST: Manage/SpecialDays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,RoomTypeId")] SpecialDays specialDays)
        {
            if (id != specialDays.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialDays);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialDaysExists(specialDays.Id))
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
            ViewBag.RoomTypes = await _context.RoomTypes.Include(h => h.Hotel).ToListAsync();

            return View(specialDays);
        }

        // GET: Manage/SpecialDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SpecialDays == null)
            {
                return NotFound();
            }

            var specialDays = await _context.SpecialDays
                .Include(s => s.RoomType).ThenInclude(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialDays == null)
            {
                return NotFound();
            }

            return View(specialDays);
        }

        // POST: Manage/SpecialDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SpecialDays == null)
            {
                return Problem("Entity set 'AppDbContext.SpecialDays'  is null.");
            }
            var specialDays = await _context.SpecialDays.FindAsync(id);
            if (specialDays != null)
            {
                _context.SpecialDays.Remove(specialDays);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialDaysExists(int id)
        {
          return (_context.SpecialDays?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
