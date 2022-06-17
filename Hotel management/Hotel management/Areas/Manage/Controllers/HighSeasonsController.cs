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
    public class HighSeasonsController : Controller
    {
        private readonly AppDbContext _context;

        public HighSeasonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/HighSeasons
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.HighSeasons.Include(h => h.Season).ThenInclude(h=>h.Hotel);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Manage/HighSeasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HighSeasons == null)
            {
                return NotFound();
            }

            var highSeason = await _context.HighSeasons
                .Include(h => h.Season).ThenInclude(h=>h.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (highSeason == null)
            {
                return NotFound();
            }

            return View(highSeason);
        }

        // GET: Manage/HighSeasons/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Seasons = await _context.Seasons.Where(h => h.HighSeason == null).Include(h => h.MidSeason).Include(h => h.LowSeason).Include(h=>h.Hotel).ToListAsync();

            return View();
        }

        // POST: Manage/HighSeasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SeasonId,January,February,March,April,May,June,July,August,September,October,November,December")] HighSeason highSeason)
        {
            ViewBag.Seasons = await _context.Seasons.Where(h => h.HighSeason == null).Include(h => h.MidSeason).Include(h => h.LowSeason).Include(h=>h.Hotel).ToListAsync();

            if (ModelState.IsValid)
            {
                _context.Add(highSeason);
                await _context.SaveChangesAsync();


                Seasons season = await _context.Seasons.Include(h=>h.LowSeason).Include(h=>h.MidSeason).Include(h=>h.HighSeason).Include(h=>h.Hotel).FirstOrDefaultAsync(h=>h.Id==highSeason.SeasonId);

                if (season.LowSeason!= null)
                    {
                    if (season.HighSeason.January==true)
                    {
                        season.LowSeason.January = false;
                    }
                    if (season.HighSeason.February == true)
                    {
                        season.LowSeason.February = false;
                    }
                    if (season.HighSeason.March == true)
                    {
                        season.LowSeason.March = false;
                    }
                    if (season.HighSeason.April == true)
                    {
                        season.LowSeason.April = false;
                    }
                    if (season.HighSeason.May == true)
                    {
                        season.LowSeason.May = false;
                    }
                    if (season.HighSeason.June == true)
                    {
                        season.LowSeason.June = false;
                    }
                    if (season.HighSeason.July == true)
                    {
                        season.LowSeason.July = false;
                    }
                    if (season.HighSeason.August == true)
                    {
                        season.LowSeason.August = false;
                    }
                    if (season.HighSeason.September == true)
                    {
                        season.LowSeason.September = false;
                    }
                    if (season.HighSeason.October == true)
                    {
                        season.LowSeason.October = false;
                    }
                    if (season.HighSeason.November == true)
                    {
                        season.LowSeason.November = false;
                    }
                    if (season.HighSeason.December == true)
                    {
                        season.LowSeason.December = false;
                    }

                }
                if (season.MidSeason != null)
                {
                    if (season.HighSeason.January == true)
                    {
                        season.MidSeason.January = false;
                    }
                    if (season.HighSeason.February == true)
                    {
                        season.MidSeason.February = false;
                    }
                    if (season.HighSeason.March == true)
                    {
                        season.MidSeason.March = false;
                    }
                    if (season.HighSeason.April == true)
                    {
                        season.MidSeason.April = false;
                    }
                    if (season.HighSeason.May == true)
                    {
                        season.MidSeason.May = false;
                    }
                    if (season.HighSeason.June == true)
                    {
                        season.MidSeason.June = false;
                    }
                    if (season.HighSeason.July == true)
                    {
                        season.MidSeason.July = false;
                    }
                    if (season.HighSeason.August == true)
                    {
                        season.MidSeason.August = false;
                    }
                    if (season.HighSeason.September == true)
                    {
                        season.MidSeason.September = false;
                    }
                    if (season.HighSeason.October == true)
                    {
                        season.MidSeason.October = false;
                    }
                    if (season.HighSeason.November == true)
                    {
                        season.MidSeason.November = false;
                    }
                    if (season.HighSeason.December == true)
                    {
                        season.MidSeason.December = false;
                    }

                }



                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(highSeason);
        }

        // GET: Manage/HighSeasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Seasons = await _context.Seasons.Where(h => h.HighSeason == null).Include(h => h.MidSeason).Include(h => h.LowSeason).Include(h=>h.Hotel).ToListAsync();

            if (id == null || _context.HighSeasons == null)
            {
                return NotFound();
            }

            var highSeason = await _context.HighSeasons.FindAsync(id);
            if (highSeason == null)
            {
                return NotFound();
            }
          

            return View(highSeason);
        }

        // POST: Manage/HighSeasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SeasonId,January,February,March,April,May,June,July,August,September,October,November,December")] HighSeason highSeason)
        {
            if (id != highSeason.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(highSeason);
                    await _context.SaveChangesAsync();

                    Seasons season = await _context.Seasons.Include(h => h.LowSeason).Include(h => h.MidSeason).Include(h => h.HighSeason).Include(h=>h.Hotel).FirstOrDefaultAsync(h => h.Id == highSeason.SeasonId);

                    if (season.LowSeason != null)
                    {
                        if (season.HighSeason.January == true)
                        {
                            season.LowSeason.January = false;
                        }
                        if (season.HighSeason.February == true)
                        {
                            season.LowSeason.February = false;
                        }
                        if (season.HighSeason.March == true)
                        {
                            season.LowSeason.March = false;
                        }
                        if (season.HighSeason.April == true)
                        {
                            season.LowSeason.April = false;
                        }
                        if (season.HighSeason.May == true)
                        {
                            season.LowSeason.May = false;
                        }
                        if (season.HighSeason.June == true)
                        {
                            season.LowSeason.June = false;
                        }
                        if (season.HighSeason.July == true)
                        {
                            season.LowSeason.July = false;
                        }
                        if (season.HighSeason.August == true)
                        {
                            season.LowSeason.August = false;
                        }
                        if (season.HighSeason.September == true)
                        {
                            season.LowSeason.September = false;
                        }
                        if (season.HighSeason.October == true)
                        {
                            season.LowSeason.October = false;
                        }
                        if (season.HighSeason.November == true)
                        {
                            season.LowSeason.November = false;
                        }
                        if (season.HighSeason.December == true)
                        {
                            season.LowSeason.December = false;
                        }

                    }
                    if (season.MidSeason != null)
                    {
                        if (season.HighSeason.January == true)
                        {
                            season.MidSeason.January = false;
                        }
                        if (season.HighSeason.February == true)
                        {
                            season.MidSeason.February = false;
                        }
                        if (season.HighSeason.March == true)
                        {
                            season.MidSeason.March = false;
                        }
                        if (season.HighSeason.April == true)
                        {
                            season.MidSeason.April = false;
                        }
                        if (season.HighSeason.May == true)
                        {
                            season.MidSeason.May = false;
                        }
                        if (season.HighSeason.June == true)
                        {
                            season.MidSeason.June = false;
                        }
                        if (season.HighSeason.July == true)
                        {
                            season.MidSeason.July = false;
                        }
                        if (season.HighSeason.August == true)
                        {
                            season.MidSeason.August = false;
                        }
                        if (season.HighSeason.September == true)
                        {
                            season.MidSeason.September = false;
                        }
                        if (season.HighSeason.October == true)
                        {
                            season.MidSeason.October = false;
                        }
                        if (season.HighSeason.November == true)
                        {
                            season.MidSeason.November = false;
                        }
                        if (season.HighSeason.December == true)
                        {
                            season.MidSeason.December = false;
                        }

                    }



                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HighSeasonExists(highSeason.Id))
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
            ViewBag.Seasons = await _context.Seasons.Where(h => h.HighSeason == null).Include(h => h.MidSeason).Include(h => h.LowSeason).Include(h=>h.Hotel).ToListAsync();

            return View(highSeason);
        }

        // GET: Manage/HighSeasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HighSeasons == null)
            {
                return NotFound();
            }

            var highSeason = await _context.HighSeasons
                .Include(h => h.Season)
                .ThenInclude(h=>h.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (highSeason == null)
            {
                return NotFound();
            }

            return View(highSeason);
        }

        // POST: Manage/HighSeasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HighSeasons == null)
            {
                return Problem("Entity set 'AppDbContext.HighSeasons'  is null.");
            }
            var highSeason = await _context.HighSeasons.FindAsync(id);
            if (highSeason != null)
            {
                _context.HighSeasons.Remove(highSeason);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HighSeasonExists(int id)
        {
          return (_context.HighSeasons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
