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

    public class ForeignDomesticTourTranslationsController : Controller
    {
        private readonly AppDbContext _context;

        public ForeignDomesticTourTranslationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/ForeignDomesticTourTranslations
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ForeignDomesticTourTranslations.Include(f => f.ForeignDomesticTour);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Manage/ForeignDomesticTourTranslations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ForeignDomesticTourTranslations == null)
            {
                return NotFound();
            }

            var foreignDomesticTourTranslations = await _context.ForeignDomesticTourTranslations
                .Include(f => f.ForeignDomesticTour)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foreignDomesticTourTranslations == null)
            {
                return NotFound();
            }

            return View(foreignDomesticTourTranslations);
        }

        // GET: Manage/ForeignDomesticTourTranslations/Create
        public IActionResult Create()
        {
            ViewData["ForeignDomesticTourId"] = new SelectList(_context.ForeignDomesticTours, "Id", "Id");
            return View();
        }

        // POST: Manage/ForeignDomesticTourTranslations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ForeignTourDescription_en,ForeignTourDescription_ru,DomesticTourDescription_en,DomesticTourDescription_ru,ForeignDomesticTourId")] ForeignDomesticTourTranslations foreignDomesticTourTranslations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foreignDomesticTourTranslations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ForeignDomesticTourId"] = new SelectList(_context.ForeignDomesticTours, "Id", "Id", foreignDomesticTourTranslations.ForeignDomesticTourId);
            return View(foreignDomesticTourTranslations);
        }

        // GET: Manage/ForeignDomesticTourTranslations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ForeignDomesticTourTranslations == null)
            {
                return NotFound();
            }

            var foreignDomesticTourTranslations = await _context.ForeignDomesticTourTranslations.FindAsync(id);
            if (foreignDomesticTourTranslations == null)
            {
                return NotFound();
            }
            ViewData["ForeignDomesticTourId"] = new SelectList(_context.ForeignDomesticTours, "Id", "Id", foreignDomesticTourTranslations.ForeignDomesticTourId);
            return View(foreignDomesticTourTranslations);
        }

        // POST: Manage/ForeignDomesticTourTranslations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ForeignTourDescription_en,ForeignTourDescription_ru,DomesticTourDescription_en,DomesticTourDescription_ru,ForeignDomesticTourId")] ForeignDomesticTourTranslations foreignDomesticTourTranslations)
        {
            if (id != foreignDomesticTourTranslations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foreignDomesticTourTranslations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForeignDomesticTourTranslationsExists(foreignDomesticTourTranslations.Id))
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
            ViewData["ForeignDomesticTourId"] = new SelectList(_context.ForeignDomesticTours, "Id", "Id", foreignDomesticTourTranslations.ForeignDomesticTourId);
            return View(foreignDomesticTourTranslations);
        }

        // GET: Manage/ForeignDomesticTourTranslations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ForeignDomesticTourTranslations == null)
            {
                return NotFound();
            }

            var foreignDomesticTourTranslations = await _context.ForeignDomesticTourTranslations
                .Include(f => f.ForeignDomesticTour)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foreignDomesticTourTranslations == null)
            {
                return NotFound();
            }

            return View(foreignDomesticTourTranslations);
        }

        // POST: Manage/ForeignDomesticTourTranslations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ForeignDomesticTourTranslations == null)
            {
                return Problem("Entity set 'AppDbContext.ForeignDomesticTourTranslations'  is null.");
            }
            var foreignDomesticTourTranslations = await _context.ForeignDomesticTourTranslations.FindAsync(id);
            if (foreignDomesticTourTranslations != null)
            {
                _context.ForeignDomesticTourTranslations.Remove(foreignDomesticTourTranslations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForeignDomesticTourTranslationsExists(int id)
        {
          return (_context.ForeignDomesticTourTranslations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
