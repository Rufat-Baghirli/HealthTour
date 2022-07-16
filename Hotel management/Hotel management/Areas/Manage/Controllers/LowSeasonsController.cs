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

    public class LowSeasonsController : Controller
    {
        private readonly AppDbContext _context;

        public LowSeasonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/LowSeasons
        public async Task<IActionResult> Index()
        {
            var LowSeasons = _context.LowSeasons.Include(l => l.Season).ThenInclude(h => h.Hotel);
            return View(await LowSeasons.ToListAsync());
        }

        // GET: Manage/LowSeasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LowSeasons == null)
            {
                return NotFound();
            }

            var lowSeason = await _context.LowSeasons
                .Include(l => l.Season).ThenInclude(h=>h.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lowSeason == null)
            {
                return NotFound();
            }

            return View(lowSeason);
        }

        // GET: Manage/LowSeasons/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Seasons = await _context.Seasons.Where(h => h.LowSeason == null).Include(h => h.HighSeason).Include(h => h.MidSeason).Include(h => h.Hotel).ToListAsync();
            return View();
        }

        // POST: Manage/LowSeasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SeasonId,January,February,March,April,May,June,July,August,September,October,November,December")] LowSeason lowSeason)
        {

            ViewBag.Seasons = await _context.Seasons.Where(h => h.LowSeason == null).Include(h => h.HighSeason).Include(h => h.MidSeason).Include(h=>h.Hotel).ToListAsync();


            if (ModelState.IsValid)
            {
                _context.Add(lowSeason);
                await _context.SaveChangesAsync();


                Seasons season = await _context.Seasons.Include(h => h.LowSeason).Include(h => h.MidSeason).Include(h => h.HighSeason).Include(h=>h.Hotel).FirstOrDefaultAsync(h => h.Id == lowSeason.SeasonId);

                if (season.MidSeason != null)
                {
                    if (season.LowSeason.January == true)
                    {
                        season.MidSeason.January = false;
                    }
                    if (season.LowSeason.February == true)
                    {
                        season.MidSeason.February = false;
                    }
                    if (season.LowSeason.March == true)
                    {
                        season.MidSeason.March = false;
                    }
                    if (season.LowSeason.April == true)
                    {
                        season.MidSeason.April = false;
                    }
                    if (season.LowSeason.May == true)
                    {
                        season.MidSeason.May = false;
                    }
                    if (season.LowSeason.June == true)
                    {
                        season.MidSeason.June = false;
                    }
                    if (season.LowSeason.July == true)
                    {
                        season.MidSeason.July = false;
                    }
                    if (season.LowSeason.August == true)
                    {
                        season.MidSeason.August = false;
                    }
                    if (season.LowSeason.September == true)
                    {
                        season.MidSeason.September = false;
                    }
                    if (season.LowSeason.October == true)
                    {
                        season.MidSeason.October = false;
                    }
                    if (season.LowSeason.November == true)
                    {
                        season.MidSeason.November = false;
                    }
                    if (season.LowSeason.December == true)
                    {
                        season.MidSeason.December = false;
                    }

                }
                if (season.HighSeason != null)
                {
                    if (season.LowSeason.January == true)
                    {
                        season.HighSeason.January = false;
                    }
                    if (season.LowSeason.February == true)
                    {
                        season.HighSeason.February = false;
                    }
                    if (season.LowSeason.March == true)
                    {
                        season.HighSeason.March = false;
                    }
                    if (season.LowSeason.April == true)
                    {
                        season.HighSeason.April = false;
                    }
                    if (season.LowSeason.May == true)
                    {
                        season.HighSeason.May = false;
                    }
                    if (season.LowSeason.June == true)
                    {
                        season.HighSeason.June = false;
                    }
                    if (season.LowSeason.July == true)
                    {
                        season.HighSeason.July = false;
                    }
                    if (season.LowSeason.August == true)
                    {
                        season.HighSeason.August = false;
                    }
                    if (season.LowSeason.September == true)
                    {
                        season.HighSeason.September = false;
                    }
                    if (season.LowSeason.October == true)
                    {
                        season.HighSeason.October = false;
                    }
                    if (season.LowSeason.November == true)
                    {
                        season.HighSeason.November = false;
                    }
                    if (season.LowSeason.December == true)
                    {
                        season.HighSeason.December = false;
                    }

                }



                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
          
            
            return View(lowSeason);
        }

        // GET: Manage/LowSeasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LowSeasons == null)
            {
                return NotFound();
            }

            var lowSeason = await _context.LowSeasons.FindAsync(id);
            if (lowSeason == null)
            {
                return NotFound();
            }
            ViewBag.Seasons = await _context.Seasons.Include(h => h.HighSeason).Include(h => h.MidSeason).Include(h=>h.Hotel).ToListAsync();

            return View(lowSeason);
        }

        // POST: Manage/LowSeasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SeasonId,January,February,March,April,May,June,July,August,September,October,November,December")] LowSeason lowSeason)
        {
            if (id != lowSeason.Id)
            {
                return NotFound();
            }
            ViewBag.Seasons = await _context.Seasons.Include(h => h.HighSeason).Include(h => h.MidSeason).Include(h => h.Hotel).ToListAsync();


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lowSeason);
                    await _context.SaveChangesAsync();


                    Seasons season = await _context.Seasons.Include(h => h.LowSeason).Include(h => h.MidSeason).Include(h => h.HighSeason).Include(h => h.Hotel).FirstOrDefaultAsync(h => h.Id == lowSeason.SeasonId);

                    if (season.MidSeason != null)
                    {
                        if (season.LowSeason.January == true)
                        {
                            season.MidSeason.January = false;
                        }
                        if (season.LowSeason.February == true)
                        {
                            season.MidSeason.February = false;
                        }
                        if (season.LowSeason.March == true)
                        {
                            season.MidSeason.March = false;
                        }
                        if (season.LowSeason.April == true)
                        {
                            season.MidSeason.April = false;
                        }
                        if (season.LowSeason.May == true)
                        {
                            season.MidSeason.May = false;
                        }
                        if (season.LowSeason.June == true)
                        {
                            season.MidSeason.June = false;
                        }
                        if (season.LowSeason.July == true)
                        {
                            season.MidSeason.July = false;
                        }
                        if (season.LowSeason.August == true)
                        {
                            season.MidSeason.August = false;
                        }
                        if (season.LowSeason.September == true)
                        {
                            season.MidSeason.September = false;
                        }
                        if (season.LowSeason.October == true)
                        {
                            season.MidSeason.October = false;
                        }
                        if (season.LowSeason.November == true)
                        {
                            season.MidSeason.November = false;
                        }
                        if (season.LowSeason.December == true)
                        {
                            season.MidSeason.December = false;
                        }

                    }
                    if (season.HighSeason != null)
                    {
                        if (season.LowSeason.January == true)
                        {
                            season.HighSeason.January = false;
                        }
                        if (season.LowSeason.February == true)
                        {
                            season.HighSeason.February = false;
                        }
                        if (season.LowSeason.March == true)
                        {
                            season.HighSeason.March = false;
                        }
                        if (season.LowSeason.April == true)
                        {
                            season.HighSeason.April = false;
                        }
                        if (season.LowSeason.May == true)
                        {
                            season.HighSeason.May = false;
                        }
                        if (season.LowSeason.June == true)
                        {
                            season.HighSeason.June = false;
                        }
                        if (season.LowSeason.July == true)
                        {
                            season.HighSeason.July = false;
                        }
                        if (season.LowSeason.August == true)
                        {
                            season.HighSeason.August = false;
                        }
                        if (season.LowSeason.September == true)
                        {
                            season.HighSeason.September = false;
                        }
                        if (season.LowSeason.October == true)
                        {
                            season.HighSeason.October = false;
                        }
                        if (season.LowSeason.November == true)
                        {
                            season.HighSeason.November = false;
                        }
                        if (season.LowSeason.December == true)
                        {
                            season.HighSeason.December = false;
                        }

                    }



                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LowSeasonExists(lowSeason.Id))
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
            return View(lowSeason);
        }

        // GET: Manage/LowSeasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LowSeasons == null)
            {
                return NotFound();
            }

            var lowSeason = await _context.LowSeasons
                .Include(l => l.Season).ThenInclude(h=>h.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lowSeason == null)
            {
                return NotFound();
            }

            return View(lowSeason);
        }

        // POST: Manage/LowSeasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LowSeasons == null)
            {
                return Problem("Entity set 'AppDbContext.LowSeasons'  is null.");
            }
            var lowSeason = await _context.LowSeasons.FindAsync(id);
            if (lowSeason != null)
            {
                _context.LowSeasons.Remove(lowSeason);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LowSeasonExists(int id)
        {
          return (_context.LowSeasons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
