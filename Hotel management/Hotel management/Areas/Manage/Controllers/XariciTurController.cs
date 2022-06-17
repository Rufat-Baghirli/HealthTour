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

    public class XariciTurController : Controller
    {
        private readonly AppDbContext _context;

        public XariciTurController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/XariciTur
        public async Task<IActionResult> Index()
        {
            return View(await _context.XariciTurlar.ToListAsync());
        }

       
        // GET: Manage/XariciTur/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manage/XariciTur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CityorCountry")] XariciTur xariciTur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(xariciTur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(xariciTur);
        }

        // GET: Manage/XariciTur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xariciTur = await _context.XariciTurlar.FindAsync(id);
            if (xariciTur == null)
            {
                return NotFound();
            }
            return View(xariciTur);
        }

        // POST: Manage/XariciTur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CityorCountry")] XariciTur xariciTur)
        {
            if (id != xariciTur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(xariciTur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!XariciTurExists(xariciTur.Id))
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
            return View(xariciTur);
        }

        // GET: Manage/XariciTur/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xariciTur = await _context.XariciTurlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (xariciTur == null)
            {
                return NotFound();
            }

            return View(xariciTur);
        }

        // POST: Manage/XariciTur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var xariciTur = await _context.XariciTurlar.FindAsync(id);
            _context.XariciTurlar.Remove(xariciTur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool XariciTurExists(int id)
        {
            return _context.XariciTurlar.Any(e => e.Id == id);
        }
    }
}
