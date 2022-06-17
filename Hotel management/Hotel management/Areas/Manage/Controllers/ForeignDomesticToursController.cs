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
    public class ForeignDomesticToursController : Controller
    {
        private readonly AppDbContext _context;

        public ForeignDomesticToursController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ForeignDomesticTours.ToListAsync());
        }

       
      

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foreignDomesticTour = await _context.ForeignDomesticTours.FindAsync(id);
            if (foreignDomesticTour == null)
            {
                return NotFound();
            }
            return View(foreignDomesticTour);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ForeignTourDescription,DomesticTourDescription")] ForeignDomesticTour foreignDomesticTour)
        {
            if (id != foreignDomesticTour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foreignDomesticTour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForeignDomesticTourExists(foreignDomesticTour.Id))
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
            return View(foreignDomesticTour);
        }


      

        private bool ForeignDomesticTourExists(int id)
        {
            return _context.ForeignDomesticTours.Any(e => e.Id == id);
        }
    }
}
