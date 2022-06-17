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

    public class TransfersController : Controller
    {
        private readonly AppDbContext _context;

        public TransfersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/Transfers
        public async Task<IActionResult> Index()
        {
              return _context.Transfers != null ? 
                          View(await _context.Transfers.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Transfers'  is null.");
        }

        // GET: Manage/Transfers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transfers == null)
            {
                return NotFound();
            }

            var transfer = await _context.Transfers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transfer == null)
            {
                return NotFound();
            }

            return View(transfer);
        }

        // GET: Manage/Transfers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manage/Transfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Car,Route,Price,IsVip")] Transfer transfer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transfer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transfer);
        }

        // GET: Manage/Transfers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transfers == null)
            {
                return NotFound();
            }

            var transfer = await _context.Transfers.FindAsync(id);
            if (transfer == null)
            {
                return NotFound();
            }
            return View(transfer);
        }

        // POST: Manage/Transfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Car,Route,Price,IsVip")] Transfer transfer)
        {
            if (id != transfer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transfer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransferExists(transfer.Id))
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
            return View(transfer);
        }

        // GET: Manage/Transfers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transfers == null)
            {
                return NotFound();
            }

            var transfer = await _context.Transfers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transfer == null)
            {
                return NotFound();
            }

            return View(transfer);
        }

        // POST: Manage/Transfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transfers == null)
            {
                return Problem("Entity set 'AppDbContext.Transfers'  is null.");
            }
            var transfer = await _context.Transfers.FindAsync(id);
            if (transfer != null)
            {
                _context.Transfers.Remove(transfer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransferExists(int id)
        {
          return (_context.Transfers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
