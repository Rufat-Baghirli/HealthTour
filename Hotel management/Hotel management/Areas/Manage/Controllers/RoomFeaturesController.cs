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

    public class RoomFeaturesController : Controller
    {
        private readonly AppDbContext _context;

        public RoomFeaturesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/RoomFeatures
        public async Task<IActionResult> Index()
        {
            var roomFeatures = _context.RoomFeatures.Where(r=>r.IsDeleted==false).Include(r => r.RoomType).ThenInclude(h=>h.Hotel);
            return View(await roomFeatures.ToListAsync());
        }

     
        // GET: Manage/RoomFeatures/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.RoomTypes = await _context.RoomTypes.Where(r=>r.IsDeleted==false).Include(h => h.Hotel).ToListAsync();
            return View();
        }

        // POST: Manage/RoomFeatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Features,RoomTypeId")] RoomFeatures roomFeatures)
        {
            ViewBag.RoomTypes = await _context.RoomTypes.Where(r => r.IsDeleted == false).Include(h => h.Hotel).ToListAsync();

            if (ModelState.IsValid)
            {
                _context.Add(roomFeatures);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomFeatures);
        }

        // GET: Manage/RoomFeatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.RoomTypes = await _context.RoomTypes.Where(r => r.IsDeleted == false).Include(h => h.Hotel).ToListAsync();

            if (id == null || _context.RoomFeatures == null)
            {
                return NotFound();
            }

            var roomFeatures = await _context.RoomFeatures.FindAsync(id);
            if (roomFeatures == null)
            {
                return NotFound();
            }
           
            return View(roomFeatures);
        }

        // POST: Manage/RoomFeatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Features,RoomTypeId")] RoomFeatures roomFeatures)
        {
            ViewBag.RoomTypes = await _context.RoomTypes.Where(r => r.IsDeleted == false).Include(h => h.Hotel).ToListAsync();

            if (id != roomFeatures.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomFeatures);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomFeaturesExists(roomFeatures.Id))
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
          
            return View(roomFeatures);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {

            if (id is null or 0)
                return NotFound();
            RoomFeatures feature = await _context.RoomFeatures.Where(n => n.IsDeleted == false).FirstOrDefaultAsync(n => n.Id == id);


            if (feature == null)
                return BadRequest();




            feature.IsDeleted = true;


            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        private bool RoomFeaturesExists(int id)
        {
          return (_context.RoomFeatures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
