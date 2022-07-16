using Hotel_management.DAL;
using Hotel_management.Extensions;
using Hotel_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class RoomTypeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public RoomTypeController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public async Task<ActionResult> Index(int page = 1)
        {
            var query = _context.RoomTypes.Where(r => r.IsDeleted == false).AsQueryable();
            IEnumerable<RoomType> types = await _context.RoomTypes.Where(r => r.IsDeleted == false).Include(r => r.RoomImages).Include(r => r.Hotel).Where(h => h.Hotel.isDeleted == false).Skip((page - 1) * 10).Take(10).OrderBy(r => r.HotelId).ThenBy(r => r.Hotel.Name).
                ToListAsync();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 10m);
            ViewBag.SelectPage = page;
            return View(types);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Hotels = await _context.Hotels.Include(r => r.Rooms.Where(r => r.IsDeleted == false)).Where(r => r.isDeleted == false).ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomType room)
        {
            ViewBag.Hotels = await _context.Hotels.Include(r => r.Rooms.Where(r => r.IsDeleted == false)).Where(r => r.isDeleted == false).ToListAsync();



            if (!ModelState.IsValid)
                return View(room);


            //var hotel = await _context.Hotels.Where(h=>h.isDeleted==false).Include(r=>r.Rooms.Where(r=>r.IsDeleted==false)).FirstOrDefaultAsync(r => r.Id == room.HotelId);

            //if (hotel.Rooms != null)
            //{
            //    foreach (RoomType item in hotel.Rooms)
            //    {
            //        if(room.Name.ToLower() == item.Name.ToLower())
            //        {
            //            ModelState.AddModelError("Name", "Otelde bu adda Roomtype artiq movcuddur");
            //            return View(room);
            //        }
            //    }
            //};



            if (room.RoomImagesFile != null)
            {
                if (room.RoomImagesFile.Length > 10)
                {
                    ModelState.AddModelError("RoomImagesFile", "Maksimum 10 Sekil Yukleye Bilersiniz");
                    return View(room);
                }

            }






            if (room.MainimgFile == null)
            {
                ModelState.AddModelError("MainImageFile", "Əsas şəkil mütləq seçilməlidir.");
                return View(room);

            }


            if (!room.MainimgFile.CheckContentType("image"))
            {
                ModelState.AddModelError("MainimgFile", "MainimgFile tipini Duzgun Secin");
                return View(room);
            }

            if (room.MainimgFile.CheckLength(5120))
            {
                ModelState.AddModelError("MainimgFile", "Seklin olcusu Maksimum 5 Mb Ola Biler");
                return View(room);
            }

            string filePath = Path.Combine(_env.WebRootPath, "images", "Rooms");

            room.Mainimg = await room.MainimgFile.SaveFileAsync(filePath);


            try
            {
                if (room.RoomImagesFile != null)
                {
                    if (room.RoomImagesFile.Length > 0)
                    {
                        List<RoomImages> roomImages = new List<RoomImages>();

                        foreach (IFormFile file in room.RoomImagesFile)
                        {
                            if (!file.CheckContentType("image"))
                            {
                                ModelState.AddModelError("RoomImagesFile", $"{file.FileName} tipini Duzgun Secin");
                                return View(room);
                            }

                            if (file.CheckLength(5120))
                            {
                                ModelState.AddModelError("HotelImagesFile", $"{file.FileName} Uzunlugu Maksimum 5 Mb Ola Biler");
                                return View(room);
                            }
                            RoomImages img = new RoomImages
                            {
                                Name = await file.SaveFileAsync(filePath)
                            };

                            roomImages.Add(img);
                        }

                        room.RoomImages = roomImages;
                    }

                }
                else
                {
                    ModelState.AddModelError("RoomImagesFile", "Sekil mutleq secilmelidir");

                }
            }

            catch
            {
                ModelState.AddModelError("RoomImagesFile", "Sekil  mutleq secilmelidir");
            }
            await _context.RoomTypes.AddAsync(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int? Id)
        {


            if (Id is null or 0)
                return NotFound();


            RoomType Roomtype = await _context.RoomTypes.Include(r => r.RoomFeatures).ThenInclude(r => r.RoomFeatureDetails).FirstOrDefaultAsync(r => r.Id == Id);
            if (Roomtype == null)
                return BadRequest();
            Roomtype.Hotel = _context.Hotels.FirstOrDefault(r => r.Id == Roomtype.HotelId);

            return View(Roomtype);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? Id, RoomType type)
        {

            if (Id is null or 0)
                return NotFound();
            RoomType roomtype = await _context.RoomTypes.Include(r => r.RoomFeatures).ThenInclude(r => r.RoomFeatureDetails).Include(r => r.RoomImages).Include(r=>r.Hotel).FirstOrDefaultAsync(r => r.Id == Id);
            if (roomtype == null)
                return BadRequest();
            try
            {





            

                if (!ModelState.IsValid)
                {
                    return View(roomtype);
                }




                if (roomtype.HotelId <= 0 && !await _context.Hotels.AnyAsync(a => a.Id == roomtype.HotelId))
                {
                    ModelState.AddModelError("HotelId", "Otel Mutleq Secilmelidi");
                    return View(roomtype);
                }

                int canUpload = 10 - roomtype.RoomImages.Count();

                if (roomtype.RoomImagesFile != null && canUpload < type.RoomImagesFile.Length)
                {
                    ModelState.AddModelError("RoomImagesFile", $"Maksumum {canUpload} Shekil Upload Ede Bilersinizi !!!!!!!");
                    return View(roomtype);
                };
                string filePath = Path.Combine(_env.WebRootPath, "images", "Rooms");

                if (type.MainimgFile != null)
                {

                    if (!type.MainimgFile.CheckContentType("image"))
                    {
                        ModelState.AddModelError("MainimgFile", "Faylin tipini Duzgun Secin");
                        return View(roomtype);
                    }

                    if (type.MainimgFile.CheckLength(5000))
                    {
                        ModelState.AddModelError("MainimgFile", "Seklin Olcusu Maksimum 5 Mb Ola Biler");
                        return View(roomtype);
                    }

                    Helpers.Exmethods.DeleteFile(filePath, roomtype.Mainimg);

                    roomtype.Mainimg = await type.MainimgFile.SaveFileAsync(filePath);

                }




                if (type.RoomImagesFile != null)
                {
                    foreach (IFormFile file in type.RoomImagesFile)
                    {
                        if (!file.CheckContentType("image"))
                        {
                            ModelState.AddModelError("RoomImagesFile", $"{file.FileName} tipini Duzgun Secin");
                            return View(roomtype);
                        }

                        if (file.CheckLength(5000))
                        {
                            ModelState.AddModelError("RoomImagesFile", $"{file.FileName} Olcusu Maksimum 5Mb Ola Biler");
                            return View(roomtype);
                        }

                        roomtype.RoomImages.ToList().Add(new RoomImages
                        {
                            Name = await file.SaveFileAsync(filePath)
                        });
                    }
                }
                roomtype.Children = type.Children;
                roomtype.Roomarea = type.Roomarea;
                roomtype.HotelId = type.HotelId;
                roomtype.People = type.People;


                roomtype.Name = type.Name;
                roomtype.OneweekPrice = type.OneweekPrice;
                roomtype.TwoweeksPrice = type.TwoweeksPrice;
                roomtype.ThreeweeksPrice = type.ThreeweeksPrice;
                roomtype.OneweekPriceMid = type.OneweekPriceMid;
                roomtype.TwoweeksPriceMid = type.TwoweeksPriceMid;
                roomtype.ThreeweeksPriceMid = type.ThreeweeksPriceMid;
                roomtype.OneweekPriceHigh = type.OneweekPriceHigh;
                roomtype.TwoweeksPriceHigh = type.TwoweeksPriceHigh;
                roomtype.ThreeweeksPriceHigh = type.ThreeweeksPriceHigh;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(roomtype);
            }


        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {

            if (id is null or 0)
                return NotFound();
            RoomType room = await _context.RoomTypes.Where(n => n.IsDeleted == false).FirstOrDefaultAsync(n => n.Id == id);


            if (room == null)
                return BadRequest();
            string path = Path.Combine(_env.WebRootPath, "images", "Rooms");
            Helpers.Exmethods.DeleteFile(path, room.Mainimg);

            if (room.RoomImages != null)
            {
                foreach (RoomImages img in room.RoomImages)
                {
                    Helpers.Exmethods.DeleteFile(path, img.Name);
                }
            }





            room.IsDeleted = true;


            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteImage(int? Id)
        {
            if (Id == null)
                return NotFound();

            RoomImages img = await _context.RoomImages.FirstOrDefaultAsync(p => p.Id == Id);
            if (img == null)
                return NotFound();

            string filePath = Path.Combine(_env.WebRootPath, "images", "Rooms");

            Helpers.Exmethods.DeleteFile(filePath, img.Name);

            int roomId = (int)img.RoomId;

            _context.RoomImages.Remove(img);
            await _context.SaveChangesAsync();


            return RedirectToAction("Update", new { Id = roomId });
        }



    }
}

