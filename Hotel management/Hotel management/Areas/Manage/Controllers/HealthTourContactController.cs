using Hotel_management.DAL;
using Hotel_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class HealthTourContactController : Controller
    {
        private readonly AppDbContext _context;

        public HealthTourContactController(AppDbContext context)
        {
            _context = context;
          

        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.HealthTourContacts.FirstOrDefaultAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.HealthTourContacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,Phone,Facebook,Instagram,Whatsapp,Twitter,Linkedin,Email")] HealthTourContact turContact)
        {
            if (id != turContact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurContactExists(turContact.Id))
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
            return View(turContact);
        }




        private bool TurContactExists(int id)
        {
            return _context.HealthTourContacts.Any(e => e.Id == id);
        }
    }
}
