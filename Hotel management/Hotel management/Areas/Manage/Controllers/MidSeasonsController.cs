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
    public class MidSeasonsController : Controller
    {
        private readonly AppDbContext _context;

        public MidSeasonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/MidSeasons
        public async Task<IActionResult> Index()
        {
            var MidSeasons = _context.MidSeasons.Include(m => m.Season).ThenInclude(h=>h.Hotel);
            return View(await MidSeasons.ToListAsync());
        }

        // GET: Manage/MidSeasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MidSeasons == null)
            {
                return NotFound();
            }

            var midSeason = await _context.MidSeasons
                .Include(m => m.Season)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (midSeason == null)
            {
                return NotFound();
            }

            return View(midSeason);
        }

        // GET: Manage/MidSeasons/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Seasons = await _context.Seasons.Where(h => h.MidSeason == null).Include(h => h.HighSeason).Include(h => h.LowSeason)
                .Include(h => h.Hotel).ToListAsync();

            return View();
        }

        // POST: Manage/MidSeasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SeasonId,January,February,March,April,May,June,July,August,September,October,November,December")] MidSeason midSeason)
        {
            ViewBag.Seasons = await _context.Seasons.Where(h => h.MidSeason == null).Include(h => h.HighSeason).Include(h => h.LowSeason).ToListAsync();


            if (ModelState.IsValid)
            {
                _context.Add(midSeason);

                await _context.SaveChangesAsync();


                Seasons season = await _context.Seasons.Include(h => h.LowSeason).Include(h => h.MidSeason).Include(h => h.HighSeason).FirstOrDefaultAsync(h => h.Id == midSeason.SeasonId);

                if (season.LowSeason != null)
                {
                    if (season.MidSeason.January == true)
                    {
                        season.LowSeason.January = false;
                    }
                    if (season.MidSeason.February == true)
                    {
                        season.LowSeason.February = false;
                    }
                    if (season.MidSeason.March == true)
                    {
                        season.LowSeason.March = false;
                    }
                    if (season.MidSeason.April == true)
                    {
                        season.LowSeason.April = false;
                    }
                    if (season.MidSeason.May == true)
                    {
                        season.LowSeason.May = false;
                    }
                    if (season.MidSeason.June == true)
                    {
                        season.LowSeason.June = false;
                    }
                    if (season.MidSeason.July == true)
                    {
                        season.LowSeason.July = false;
                    }
                    if (season.MidSeason.August == true)
                    {
                        season.LowSeason.August = false;
                    }
                    if (season.MidSeason.September == true)
                    {
                        season.LowSeason.September = false;
                    }
                    if (season.MidSeason.October == true)
                    {
                        season.LowSeason.October = false;
                    }
                    if (season.MidSeason.November == true)
                    {
                        season.LowSeason.November = false;
                    }
                    if (season.MidSeason.December == true)
                    {
                        season.LowSeason.December = false;
                    }

                }
                if (season.HighSeason != null)
                {
                    if (season.MidSeason.January == true)
                    {
                        season.HighSeason.January = false;
                    }
                    if (season.MidSeason.February == true)
                    {
                        season.HighSeason.February = false;
                    }
                    if (season.MidSeason.March == true)
                    {
                        season.HighSeason.March = false;
                    }
                    if (season.MidSeason.April == true)
                    {
                        season.HighSeason.April = false;
                    }
                    if (season.MidSeason.May == true)
                    {
                        season.HighSeason.May = false;
                    }
                    if (season.MidSeason.June == true)
                    {
                        season.HighSeason.June = false;
                    }
                    if (season.MidSeason.July == true)
                    {
                        season.HighSeason.July = false;
                    }
                    if (season.MidSeason.August == true)
                    {
                        season.HighSeason.August = false;
                    }
                    if (season.MidSeason.September == true)
                    {
                        season.HighSeason.September = false;
                    }
                    if (season.MidSeason.October == true)
                    {
                        season.HighSeason.October = false;
                    }
                    if (season.MidSeason.November == true)
                    {
                        season.HighSeason.November = false;
                    }
                    if (season.MidSeason.December == true)
                    {
                        season.HighSeason.December = false;
                    }

                }



                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(midSeason);
        }

        // GET: Manage/MidSeasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MidSeasons == null)
            {
                return NotFound();
            }

            var midSeason = await _context.MidSeasons.FindAsync(id);
            if (midSeason == null)
            {
                return NotFound();
            }
            ViewBag.Seasons = await _context.Seasons.Where(h => h.MidSeason == null).Include(h => h.HighSeason).Include(h => h.LowSeason).ToListAsync();

            return View(midSeason);
        }

        // POST: Manage/MidSeasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SeasonId,January,February,March,April,May,June,July,August,September,October,November,December")] MidSeason midSeason)
        {
            ViewBag.Seasons = await _context.Seasons.Where(h => h.MidSeason == null).Include(h => h.HighSeason).Include(h => h.LowSeason).ToListAsync();


            if (id != midSeason.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(midSeason);
                    await _context.SaveChangesAsync();

                    Seasons season = await _context.Seasons.Include(h => h.LowSeason).Include(h => h.MidSeason).Include(h => h.HighSeason).Include(h => h.Hotel).FirstOrDefaultAsync(h => h.Id == midSeason.SeasonId);


                    if (season.LowSeason != null)
                    {
                        if (season.MidSeason.January == true)
                        {
                            season.LowSeason.January = false;
                        }
                        if (season.MidSeason.February == true)
                        {
                            season.LowSeason.February = false;
                        }
                        if (season.MidSeason.March == true)
                        {
                            season.LowSeason.March = false;
                        }
                        if (season.MidSeason.April == true)
                        {
                            season.LowSeason.April = false;
                        }
                        if (season.MidSeason.May == true)
                        {
                            season.LowSeason.May = false;
                        }
                        if (season.MidSeason.June == true)
                        {
                            season.LowSeason.June = false;
                        }
                        if (season.MidSeason.July == true)
                        {
                            season.LowSeason.July = false;
                        }
                        if (season.MidSeason.August == true)
                        {
                            season.LowSeason.August = false;
                        }
                        if (season.MidSeason.September == true)
                        {
                            season.LowSeason.September = false;
                        }
                        if (season.MidSeason.October == true)
                        {
                            season.LowSeason.October = false;
                        }
                        if (season.MidSeason.November == true)
                        {
                            season.LowSeason.November = false;
                        }
                        if (season.MidSeason.December == true)
                        {
                            season.LowSeason.December = false;
                        }

                    }
                    if (season.HighSeason != null)
                    {
                        if (season.MidSeason.January == true)
                        {
                            season.HighSeason.January = false;
                        }
                        if (season.MidSeason.February == true)
                        {
                            season.HighSeason.February = false;
                        }
                        if (season.MidSeason.March == true)
                        {
                            season.HighSeason.March = false;
                        }
                        if (season.MidSeason.April == true)
                        {
                            season.HighSeason.April = false;
                        }
                        if (season.MidSeason.May == true)
                        {
                            season.HighSeason.May = false;
                        }
                        if (season.MidSeason.June == true)
                        {
                            season.HighSeason.June = false;
                        }
                        if (season.MidSeason.July == true)
                        {
                            season.HighSeason.July = false;
                        }
                        if (season.MidSeason.August == true)
                        {
                            season.HighSeason.August = false;
                        }
                        if (season.MidSeason.September == true)
                        {
                            season.HighSeason.September = false;
                        }
                        if (season.MidSeason.October == true)
                        {
                            season.HighSeason.October = false;
                        }
                        if (season.MidSeason.November == true)
                        {
                            season.HighSeason.November = false;
                        }
                        if (season.MidSeason.December == true)
                        {
                            season.HighSeason.December = false;
                        }

                    }



                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MidSeasonExists(midSeason.Id))
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
            return View(midSeason);
        }

        // GET: Manage/MidSeasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MidSeasons == null)
            {
                return NotFound();
            }

            var midSeason = await _context.MidSeasons
                .Include(m => m.Season).ThenInclude(h=>h.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (midSeason == null)
            {
                return NotFound();
            }

            return View(midSeason);
        }

        // POST: Manage/MidSeasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MidSeasons == null)
            {
                return Problem("Entity set 'AppDbContext.MidSeasons'  is null.");
            }
            var midSeason = await _context.MidSeasons.FindAsync(id);
            if (midSeason != null)
            {
                _context.MidSeasons.Remove(midSeason);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MidSeasonExists(int id)
        {
          return (_context.MidSeasons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
