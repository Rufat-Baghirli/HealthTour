using Hotel_management.DAL;
using Hotel_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_management.Extensions;
using System.Text;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class HotelController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HotelController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public async Task<ActionResult> Index()
        {
            return View(await _context.Hotels.Include(r => r.Location).Where(r => r.isDeleted == false).ToListAsync());
        }




        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Locations = await _context.Locations.ToListAsync();
            ViewBag.Ratings = await _context.HotelStars.ToListAsync();





            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Hotel hotel)
        {
            ViewBag.Locations = await _context.Locations.ToListAsync();
            ViewBag.Ratings = await _context.HotelStars.ToListAsync();


            try
            {


                if (hotel.LocationId <= 0 && !await _context.Locations.AnyAsync(a => a.Id == hotel.LocationId))
                {
                    ModelState.AddModelError("LocationId", "Location Mutleq Secilmelidi");
                    return View(hotel);
                }




                if (hotel.HotelImagesFile != null)
                {
                    if (hotel.HotelImagesFile.Length > 10)
                    {
                        ModelState.AddModelError("HotelImagesFile", "Maksimum 10 Sekil Yukleye Bilersiniz");
                        return View(hotel);
                    }

                }


                if (await _context.Hotels.AnyAsync(g => g.Name.ToLower() == hotel.Name.ToLower()))
                {
                    ModelState.AddModelError("Name", $"Bu {hotel.Name} Adda Artiq Otel Var");
                    return View(hotel);
                }




                if (hotel.MainimgFile == null)
                {
                    ModelState.AddModelError("MainImageFile", "Əsas şəkil mütləq seçilməlidir.");
                    return View(hotel);

                }


                if (!hotel.MainimgFile.CheckContentType("image"))
                {
                    ModelState.AddModelError("MainImageFile", "MainImageFile tipini Duzgun Secin");
                    return View(hotel);
                }

                if (hotel.MainimgFile.CheckLength(5120))
                {
                    ModelState.AddModelError("MainImageFile", "MainImageFile Uzunlugu Maksimum 5 Mb Ola Biler");
                    return View(hotel);
                }

                string filePath = Path.Combine(_env.WebRootPath, "images", "Hotels");

                hotel.Mainimg = await hotel.MainimgFile.SaveFileAsync(filePath);


                try
                {
                    if (hotel.HotelImagesFile != null)
                    {
                        if (hotel.HotelImagesFile.Length > 0)
                        {
                            List<HotelImages> HotelImages = new List<HotelImages>();

                            foreach (IFormFile file in hotel.HotelImagesFile)
                            {
                                if (!file.CheckContentType("image"))
                                {
                                    ModelState.AddModelError("HotelImagesFile", $"{file.FileName} tipini Duzgun Secin");
                                    return View(hotel);
                                }

                                if (file.CheckLength(5120))
                                {
                                    ModelState.AddModelError("HotelImagesFile", $"{file.FileName} Uzunlugu Maksimum 5 Mb Ola Biler");
                                    return View(hotel);
                                }
                                HotelImages HotelImage = new HotelImages
                                {
                                    Name = await file.SaveFileAsync(filePath)
                                };

                                HotelImages.Add(HotelImage);
                            }

                            hotel.HotelImages = HotelImages;
                        }
                    }

                    else
                    {
                        ModelState.AddModelError("hotel.HotelImagesFile", "Hotel images mutleq secilmelidir");

                    }
                }

                catch
                {
                    ModelState.AddModelError("hotel.HotelImagesFile", "Hotel images mutleq secilmelidir");
                }

                await _context.Hotels.AddAsync(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            catch
            {
                return View(hotel);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Update(int? Id)
        {
            ViewBag.Locations = await _context.Locations.ToListAsync();
            ViewBag.Ratings = await _context.HotelStars.ToListAsync();

            if (Id == null)
                return NotFound();

            Hotel hotel = await _context.Hotels.Include(p => p.HotelImages).FirstOrDefaultAsync(p => p.Id == Id);

            if (hotel == null)
                return NotFound();

            return View(hotel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? Id, Hotel hotel)
        {
            ViewBag.Locations = await _context.Locations.ToListAsync();
            ViewBag.Ratings = await _context.HotelStars.ToListAsync();

            if (Id == null)
                return NotFound();

            Hotel dbhotel = await _context.Hotels.Include(p => p.HotelImages).FirstOrDefaultAsync(p => p.Id == Id);

            if (dbhotel == null)
                return NotFound();



            if (hotel.Location != null && !await _context.Locations.AnyAsync(a => a.Id == hotel.LocationId))
            {
                ModelState.AddModelError("LocationId", "Location Mutleq Secilmelidi");
                return View(hotel);
            }


            int canUpload = 10 - dbhotel.HotelImages.Count();

            if (hotel.HotelImagesFile != null && canUpload < hotel.HotelImagesFile.Length)
            {
                ModelState.AddModelError("HotelImagesFile", $"Maksumum {canUpload} Shekil Upload Ede Bilersiniz!");
                return View(dbhotel);
            }

            string filePath = Path.Combine(_env.WebRootPath, "images", "Hotels");

            if (hotel.MainimgFile != null)
            {

                if (!hotel.MainimgFile.CheckContentType("image"))
                {
                    ModelState.AddModelError("MainimgFile", "MainimgFile tipini Duzgun Secin");
                    return View(dbhotel);
                }

                if (hotel.MainimgFile.CheckLength(5120))
                {
                    ModelState.AddModelError("MainimgFile", "MainimgFile Uzunlugu Maksimum 5 Mb Ola Biler");
                    return View(dbhotel);
                }

                Helpers.Exmethods.DeleteFile(filePath, dbhotel.Mainimg);

                dbhotel.Mainimg = await hotel.MainimgFile.SaveFileAsync(filePath);

            }




            if (hotel.HotelImagesFile != null)
            {
                foreach (IFormFile file in hotel.HotelImagesFile)
                {
                    if (!file.CheckContentType("image"))
                    {
                        ModelState.AddModelError("HotelImagesFile", $"{file.FileName} tipini Duzgun Secin");
                        return View(hotel);
                    }

                    if (file.CheckLength(5120))
                    {
                        ModelState.AddModelError("HotelImagesFile", $"{file.FileName} Uzunlugu Maksimum 5 Mb Ola Biler");
                        return View(hotel);
                    }

                    dbhotel.HotelImages.Add(new HotelImages
                    {
                        Name = await file.SaveFileAsync(filePath)
                    });
                }
            }

            dbhotel.LocationId = hotel.LocationId;
            dbhotel.Name = hotel.Name;
            dbhotel.Rooms = hotel.Rooms;
            dbhotel.HotelFeatures = hotel.HotelFeatures;
            dbhotel.Description = hotel.Description;
            dbhotel.MapLocation = hotel.MapLocation;


            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Hotel hotel = await _context.Hotels.Where(n => n.isDeleted == false).FirstOrDefaultAsync(n => n.Id == id);


            if (hotel == null)
                return BadRequest();
            string path = Path.Combine(_env.WebRootPath, "images", "Hotels");
            Helpers.Exmethods.DeleteFile(path, hotel.Mainimg);


            if (hotel.HotelImages != null)
            {
                foreach (HotelImages hotelImage in hotel.HotelImages)
                {
                    Helpers.Exmethods.DeleteFile(path, hotelImage.Name);
                }
            }





            hotel.isDeleted = true;
            if (hotel.Rooms != null)
            {
                foreach (RoomType room in hotel.Rooms)
                {
                    room.IsDeleted = true;
                }
            }

            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteHotelImage(int? Id)
        {
            if (Id == null)
                return NotFound();

            HotelImages hotelImage = await _context.HotelImages.FirstOrDefaultAsync(p => p.Id == Id);
            if (hotelImage == null)
                return NotFound();

            string filePath = Path.Combine(_env.WebRootPath, "images", "Hotels");

            Helpers.Exmethods.DeleteFile(filePath, hotelImage.Name);

            int hotelId = hotelImage.HotelId;

            _context.HotelImages.Remove(hotelImage);
            await _context.SaveChangesAsync();


            return RedirectToAction("Update", new { Id = hotelId });
        }

        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            Hotel hotel = await _context.Hotels.Include(c => c.HotelImages).Include(h => h.HotelFeatures).ThenInclude(h => h.HotelFeatureDetails).Include(r => r.HotelStar).Include(h => h.Location).Include(r => r.Rooms).FirstOrDefaultAsync(h => h.Id == Id);
            if (hotel == null)
            {
                return BadRequest();
            }

            return View(hotel);
        }


    }
}
