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

    public class TreatmentTranslationsController : Controller
    {
        private readonly AppDbContext _context;

        public TreatmentTranslationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/TreatmentTranslations
        public async Task<IActionResult> Index()
        {
            var treatments = _context.TreatmentTranslations.Include(t => t.Treatment).ThenInclude(t=>t.Hotel);
            return View(await treatments.ToListAsync());
        }

        // GET: Manage/TreatmentTranslations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TreatmentTranslations == null)
            {
                return NotFound();
            }

            var treatmentTranslations = await _context.TreatmentTranslations
                .Include(t => t.Treatment).ThenInclude(t=>t.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treatmentTranslations == null)
            {
                return NotFound();
            }

            return View(treatmentTranslations);
        }

        // GET: Manage/TreatmentTranslations/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Treatments = await _context.Treatments.Include(t => t.Hotel).ToListAsync();
            return View();
        }

        // POST: Manage/TreatmentTranslations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name_en,Name_ru,Description_en,Description_ru,TreatmentId")] TreatmentTranslations treatmentTranslations)
        {
            ViewBag.Treatments = await _context.Treatments.Include(t=>t.Hotel).ToListAsync();


            if (ModelState.IsValid)
            {
                _context.Add(treatmentTranslations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(treatmentTranslations);
        }

        // GET: Manage/TreatmentTranslations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Treatments = await _context.Treatments.Include(t => t.Hotel).ToListAsync();

            if (id == null || _context.TreatmentTranslations == null)
            {
                return NotFound();
            }

            var treatmentTranslations = await _context.TreatmentTranslations.FindAsync(id);
            if (treatmentTranslations == null)
            {
                return NotFound();
            }
            return View(treatmentTranslations);
        }

        // POST: Manage/TreatmentTranslations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name_en,Name_ru,Description_en,Description_ru,TreatmentId")] TreatmentTranslations treatmentTranslations)
        {
            ViewBag.Treatments = await _context.Treatments.Include(t => t.Hotel).ToListAsync();

            if (id != treatmentTranslations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treatmentTranslations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentTranslationsExists(treatmentTranslations.Id))
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
            return View(treatmentTranslations);
        }

        // GET: Manage/TreatmentTranslations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TreatmentTranslations == null)
            {
                return NotFound();
            }

            var treatmentTranslations = await _context.TreatmentTranslations
                .Include(t => t.Treatment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treatmentTranslations == null)
            {
                return NotFound();
            }

            return View(treatmentTranslations);
        }

        // POST: Manage/TreatmentTranslations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TreatmentTranslations == null)
            {
                return Problem("Entity set 'AppDbContext.TreatmentTranslations'  is null.");
            }
            var treatmentTranslations = await _context.TreatmentTranslations.FindAsync(id);
            if (treatmentTranslations != null)
            {
                _context.TreatmentTranslations.Remove(treatmentTranslations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreatmentTranslationsExists(int id)
        {
          return (_context.TreatmentTranslations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
