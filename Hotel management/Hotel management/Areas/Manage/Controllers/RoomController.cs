using Hotel_management.DAL;
using Hotel_management.Extensions;
using Hotel_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class RoomController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public RoomController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = _context.Rooms.Where(r => r.isDeleted == false).AsQueryable();
            IEnumerable<Room> rooms = await _context.Rooms.Include(r => r.RoomImages).Include(r => r.RoomType).Include(r => r.Hotel).Where(r => r.isDeleted == false).Skip((page - 1) * 10).Take(10).
                ToListAsync();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 10m);
            ViewBag.SelectPage = page;
            return View(rooms);

        }

        // GET: RoomController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Roomtypes = await _context.RoomTypes.Where(h => h.IsDeleted == false).Include(r => r.Hotel).ToListAsync();


            return View();
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Room room)
        {
            ViewBag.Roomtypes = await _context.RoomTypes.Where(h => h.IsDeleted == false).Include(r => r.Hotel).ToListAsync();



            try
            {
                if (room.RoomTypeId != 0)
                {
                    room.RoomType = await _context.RoomTypes.Include(r=>r.Hotel).FirstOrDefaultAsync(r=>r.Id==room.RoomTypeId);
                    room.Hotel = room.RoomType.Hotel;
                    room.HotelId = room.Hotel.Id;
                    

                }

                if (room.HotelId <= 0 && !await _context.Hotels.AnyAsync(a => a.Id == room.HotelId))
                {
                    ModelState.AddModelError("HotelId", "Otel Mutleq Secilmelidi");
                    return View(room);
                }



                if (room.RoomImagesFile != null)
                {
                    if (room.RoomImagesFile.Length > 10)
                    {
                        ModelState.AddModelError("RoomImagesFile", "Maksimum 10 Sekil Yukleye Bilersiniz");
                        return View(room);
                    }

                }


                if (room.RoomTypeId <= 0 && !await _context.RoomTypes.AnyAsync(a => a.Id == room.RoomTypeId))
                {
                    ModelState.AddModelError("RoomTypeId", "Otagin tipi Secilmelidi");
                    return View(room);
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

                if (room.MainimgFile.CheckLength(500))
                {
                    ModelState.AddModelError("MainimgFile", "Seklin olcusu Maksimum 500 kb Ola Biler");
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

                                if (file.CheckLength(500))
                                {
                                    ModelState.AddModelError("HotelImagesFile", $"{file.FileName} Uzunlugu Maksimum 500 kb Ola Biler");
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

             

                await _context.Rooms.AddAsync(room);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            catch
            {
                return View(room);
            }
        }


        public async Task<ActionResult> Update(int? id)
        {
            

            if (id == null || id == 0)
                return NotFound();

            Room room = await _context.Rooms.Include(h=>h.Hotel).Include(r=>r.RoomType).Include(r=>r.RoomFeatures).Include(r=>r.RoomImages).FirstOrDefaultAsync(r=>r.Id==id);

           if( room == null)
            return BadRequest();

           

            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int? id, Room room)
        {
           
            try
            {
               if(id==0 || id == null)
                return NotFound();

                Room dbroom = await _context.Rooms.Include(h => h.Hotel).Include(r => r.RoomType).Include(r => r.RoomFeatures).Include(r => r.RoomImages).FirstOrDefaultAsync(r => r.Id == id);

                if (dbroom == null)
                return BadRequest();


               

                if (room.HotelId <= 0 && !await _context.Hotels.AnyAsync(a => a.Id == room.HotelId))
                {
                    ModelState.AddModelError("HotelId", "Otel Mutleq Secilmelidi");
                    return View(room);
                }
                if (room.RoomTypeId <= 0 && !await _context.RoomTypes.AnyAsync(a => a.Id == room.RoomTypeId))
                {
                    ModelState.AddModelError("RoomTypeId", "Otagin tipi Secilmelidi");
                    return View(room);
                }

                int canUpload = 10 - dbroom.RoomImages.Count();

                if (room.RoomImagesFile != null && canUpload < room.RoomImagesFile.Length)
                {
                    ModelState.AddModelError("RoomImagesFile", $"Maksumum {canUpload} Shekil Upload Ede Bilersinizi !!!!!!!");
                    return View(dbroom);
                };
                string filePath = Path.Combine(_env.WebRootPath, "images", "Rooms");

                if (room.MainimgFile != null)
                {

                    if (!room.MainimgFile.CheckContentType("image"))
                    {
                        ModelState.AddModelError("MainimgFile", "Faylin tipini Duzgun Secin");
                        return View(room);
                    }

                    if (room.MainimgFile.CheckLength(500))
                    {
                        ModelState.AddModelError("MainimgFile", "Seklin Olcusu Maksimum 500 kb Ola Biler");
                        return View(room);
                    }

                    Helpers.Exmethods.DeleteFile(filePath, dbroom.Mainimg);

                    dbroom.Mainimg = await room.MainimgFile.SaveFileAsync(filePath);

                }




                if (room.RoomImagesFile != null)
                {
                    foreach (IFormFile file in room.RoomImagesFile)
                    {
                        if (!file.CheckContentType("image"))
                        {
                            ModelState.AddModelError("RoomImagesFile", $"{file.FileName} tipini Duzgun Secin");
                            return View(room);
                        }

                        if (file.CheckLength(500))
                        {
                            ModelState.AddModelError("RoomImagesFile", $"{file.FileName} Olcusu Maksimum 500 kb Ola Biler");
                            return View(room);
                        }

                        dbroom.RoomImages.ToList().Add(new RoomImages
                        {
                            Name = await file.SaveFileAsync(filePath)
                        });
                    }
                }
             dbroom.Children = room.Children;
            dbroom.Roomarea = room.Roomarea;
                dbroom.HotelId = room.HotelId;
                dbroom.People = room.People;
                dbroom.RoomTypeId = room.RoomTypeId;
                dbroom.Smoking = room.Smoking;


                await _context.SaveChangesAsync();

               return RedirectToAction ("Index");

            }
            catch
            {
                return View(room);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Room room = await _context.Rooms.Where(n => n.isDeleted == false).FirstOrDefaultAsync(n => n.Id == id);


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





            room.isDeleted = true;
             

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

            int roomId = img.RoomId;

            _context.RoomImages.Remove(img);
            await _context.SaveChangesAsync();


            return RedirectToAction("Update", new { Id = roomId });
        }

        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null || Id==0)
                return NotFound();

            var Room =  _context.Rooms.Where(r=>r.isDeleted==false).
                Include(r=>r.Hotel).ThenInclude(r => r.ExtraPrice).
                Include(r=>r.RoomFeatures).
                ThenInclude(r=>r.RoomFeatureDetails).
                Include(r=>r.RoomType).
                Include(r=>r.RoomImages).
                FirstOrDefault(r=>r.Id==Id);
            if (Room == null)
                return BadRequest();

          return View(Room);
        }
    }
}
