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
using Hotel_management.Extensions;
using Microsoft.AspNetCore.Authorization;


namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class AboutImagesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutImagesController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        // GET: Manage/AboutImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutImages.ToListAsync());
        }

        // GET: Manage/AboutImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutImg = await _context.AboutImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutImg == null)
            {
                return NotFound();
            }

            return View(aboutImg);
        }

        // GET: Manage/AboutImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manage/AboutImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImgFile")] AboutImg aboutImg)
        {
            
                if (aboutImg.ImgFile == null)
                {
                    ModelState.AddModelError("ImgFile", "Şəkil mütləq seçilməlidir.");
                    return View(aboutImg);

                }


                if (!aboutImg.ImgFile.CheckContentType("image"))
                {
                    ModelState.AddModelError("ImgFile", "Filein tipini Duzgun Secin");
                    return View(aboutImg);
                }

                if (aboutImg.ImgFile.CheckLength(5120))
                {
                    ModelState.AddModelError("ImgFile", "Seklin olcusu Maksimum 5 mb Ola Biler");
                    return View(aboutImg);
                }


                string filePath = Path.Combine(_env.WebRootPath, "images", "About");

                aboutImg.Img = await aboutImg.ImgFile.SaveFileAsync(filePath);
                _context.Add(aboutImg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }

     
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutImg = await _context.AboutImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutImg == null)
            {
                return NotFound();
            }

            return View(aboutImg);
        }

        // POST: Manage/AboutImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            AboutImg aboutImg = await _context.AboutImages.FindAsync(id);
            string path = Path.Combine(_env.WebRootPath, "images", "About");
            Helpers.Exmethods.DeleteFile(path, aboutImg.Img);

            _context.AboutImages.Remove(aboutImg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutImgExists(int id)
        {
            return _context.AboutImages.Any(e => e.Id == id);
        }
    }
}
