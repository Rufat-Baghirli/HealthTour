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

    public class DaxiliTurController : Controller
    {
        private readonly AppDbContext _context;

        public DaxiliTurController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/DaxiliTur
        public async Task<IActionResult> Index()
        {
            return View(await _context.DaxiliTurlar.ToListAsync());
        }

    
       
        // GET: Manage/DaxiliTur/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manage/DaxiliTur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,City")] DaxiliTur daxiliTur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daxiliTur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(daxiliTur);
        }

        // GET: Manage/DaxiliTur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daxiliTur = await _context.DaxiliTurlar.FindAsync(id);
            if (daxiliTur == null)
            {
                return NotFound();
            }
            return View(daxiliTur);
        }

        // POST: Manage/DaxiliTur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,City")] DaxiliTur daxiliTur)
        {
            if (id != daxiliTur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daxiliTur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DaxiliTurExists(daxiliTur.Id))
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
            return View(daxiliTur);
        }

        // GET: Manage/DaxiliTur/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daxiliTur = await _context.DaxiliTurlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (daxiliTur == null)
            {
                return NotFound();
            }

            return View(daxiliTur);
        }

        // POST: Manage/DaxiliTur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var daxiliTur = await _context.DaxiliTurlar.FindAsync(id);
            _context.DaxiliTurlar.Remove(daxiliTur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DaxiliTurExists(int id)
        {
            return _context.DaxiliTurlar.Any(e => e.Id == id);
        }
    }
}
