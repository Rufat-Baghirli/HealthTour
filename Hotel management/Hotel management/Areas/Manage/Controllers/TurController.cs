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
using Hotel_management.Extensions;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class TurController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TurController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }


        // GET: Manage/Tur
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tours.Where(t=>t.IsDeleted==false).ToListAsync());
        }

        // GET: Manage/Tur/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

       
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Imagefile,Description,Price,IsXarici")] Tour tour)
        {

            if (tour.Imagefile == null)
            {
                ModelState.AddModelError("Imagefile", "Şəkil mütləq seçilməlidir.");
                return View(tour);

            }


            if (!tour.Imagefile.CheckContentType("image"))
            {
                ModelState.AddModelError("Imagefile", "Filein tipini Duzgun Secin");
                return View(tour);
            }

            if (tour.Imagefile.CheckLength(5120))
            {
                ModelState.AddModelError("Imagefile", "Seklin olcusu Maksimum 5 Mb Ola Biler");
                return View(tour);
            }


            string filePath = Path.Combine(_env.WebRootPath, "images", "Tour");

            tour.Img = await tour.Imagefile.SaveFileAsync(filePath);



            await _context.Tours.AddAsync(tour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Manage/Tur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }
            return View(tour);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Imagefile,Description,Price,IsXarici")] Tour tour)
        {
            if (id != tour.Id)
            {
                return NotFound();
            }

            Tour Dbtour = await _context.Tours.FindAsync(tour.Id);

            if (Dbtour == null)
            {
                return BadRequest();

            }

            string filePath = Path.Combine(_env.WebRootPath, "images", "Tour");

            if (tour.Imagefile != null)
            {

                if (!tour.Imagefile.CheckContentType("image"))
                {
                    ModelState.AddModelError("Imagefile", "Faylin tipini Duzgun Secin");
                    return View(tour);
                }

                if (tour.Imagefile.CheckLength(5120))
                {
                    ModelState.AddModelError("Imagefile", "Seklin Olcusu Maksimum 5 Mb Ola Biler");
                    return View(tour);
                }

                Helpers.Exmethods.DeleteFile(filePath, Dbtour.Img);
                Dbtour.Img = await tour.Imagefile.SaveFileAsync(filePath);


            }

            if (tour.Imagefile == null)
            {
                ModelState.AddModelError("Imagefile", "Şəkil mütləq seçilməlidir.");
                return View(tour);

            }


            Dbtour.Price = tour.Price;
                Dbtour.Description = tour.Description;
                Dbtour.IsXarici = tour.IsXarici;
                Dbtour.Name = tour.Name;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            // GET: Manage/Tur/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tour = await _context.Tours
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (tour == null)
                {
                    return NotFound();
                }

                return View(tour);
            }

            // POST: Manage/Tur/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                Tour tour = await _context.Tours.FindAsync(id);
            string path = Path.Combine(_env.WebRootPath, "images", "Tour");
            Helpers.Exmethods.DeleteFile(path, tour.Img);
            tour.IsDeleted = true;
            await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool TourExists(int id)
            {
                return _context.Tours.Any(e => e.Id == id);
            }
        }
    }
