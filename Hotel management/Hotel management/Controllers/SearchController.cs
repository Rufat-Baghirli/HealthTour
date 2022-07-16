using Hotel_management.DAL;
using Hotel_management.Models;
using Hotel_management.ViewModels.SearchRoomViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Linq;
//using Newtonsoft.Json;
using System.Text.Json;

namespace Hotel_management.Controllers
{
    public class SearchController : Controller
    {

        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _usermanager;
        private readonly IStringLocalizer<SharedResource> _localizer;




        public SearchController(AppDbContext context, UserManager<AppUser> usermanager, IStringLocalizer<SharedResource> localizer)
        {
            _usermanager = usermanager;
            _context = context;
            _localizer = localizer;

        }


        public async Task<IActionResult> SearchResult(SearchRoomVM vm)
        {

            

            if (vm.Adults != null)
            {
                for (int y = 0; y < vm.Adults.Count; y++)
                {
                    if (vm.Adults[y] == null)
                    {
                        vm.Adults.RemoveAt(y);


                    }
                }
            }

            if (vm.Childs != null)
            {
                for (int z = 0; z < vm.Childs.Count; z++)
                {
                    if (vm.Childs[z] == null)
                    {
                        vm.Childs.RemoveAt(z);


                    }
                };
            }

            if (vm.Checkout < vm.Checkin ||
                vm.Checkout < DateTime.Today ||
                vm.Checkin < DateTime.Today
                )
            {
                TempData["SearchRoomError"] = _localizer["No results were found for these dates"].ToString();


                return View();


            }


            if (vm.Adults == null || vm.Adults.Count < 1)
            {
                TempData["SearchRoomError"] = _localizer["At least 1 person must be included"].ToString();
                return View();
            }
            else if (vm.Adults.Count>2)
            {
                TempData["SearchRoomError"] = _localizer["Maximum two adults can be added"].ToString();
                return View();
            }


            if (vm.Childs != null)
            {
                for (int i = 0; i < vm.Childs.Count; i++)
                {
                    for (int j = i + 1; j < vm.Childs.Count; j++)
                    {


                        if (vm.Childs[i].Id == vm.Childs[j].Id)
                        {
                            foreach (Child child in vm.Childs)
                            {
                                child.Id = Guid.NewGuid();

                            }
                        }
                    }
                }


            }





            IQueryable<Hotel> Hotels = from h in _context.Hotels.Include(h => h.Location).Include(h => h.ExtraPrice).Include(h => h.HotelFeatures).ThenInclude(h => h.HotelFeatureTranslations)
                         .Include(h => h.HotelFeatures.Where(h=>h.IsDeleted==false)).ThenInclude(h => h.HotelFeatureDetails).ThenInclude(h => h.hotelFeatureDetailsTranslations).
                         Include(h => h.HotelImages).Include(h => h.HotelStar).Include(h => h.Reviews).Include(h => h.Rooms).ThenInclude(h => h.SpecialDays).Include(h => h.Treatments).Include(h => h.hotelTranslations).
                         Include(h => h.Season).ThenInclude(h => h.HighSeason).Include(h => h.Season).ThenInclude(h => h.MidSeason).Include(h => h.Season).ThenInclude(h => h.LowSeason)
                                       where
                                                      h.isDeleted == false &&
                                                      ((h.Name.ToLower().Contains(vm.Location.ToLower()))
                                                      ||
                                                      (h.Location.City.ToLower().Contains(vm.Location.ToLower())))


                                                      

                                       select h;


            if (Hotels == null || Hotels.Count() < 1)
            {
                TempData["SearchRoomError"] = _localizer["No suitable hotel was found"].ToString();
                return View();

            }

            foreach (Hotel hotel in Hotels)
            {
                if (!hotel.Name.ToLower().Contains("Chenot".ToLower()))
                {
                    if (Helpers.Extentions.Compare(vm.Checkout, vm.Checkin) < 7)
                    {
                        TempData["SearchRoomError"] = _localizer["It is not possible to book less than 7 days at these hotels"].ToString();
                        return View();
                    }
                }
                else
                {
                    if (Helpers.Extentions.Compare(vm.Checkout, vm.Checkin) != 3 && Helpers.Extentions.Compare(vm.Checkout, vm.Checkin) != 7 && Helpers.Extentions.Compare(vm.Checkout, vm.Checkin) != 14)
                    {
                        TempData["SearchRoomError"] = _localizer["Only 3, 7, 14 day packages are available for Chenot hotel"].ToString();
                        return View();
                    }
                }
            }

            vm.Hotels = await Hotels.ToListAsync();
         




            if (vm.Childs == null)
            {
                IQueryable<RoomType> availablerooms = from r in  _context.RoomTypes.
              Where
              (r => (r.People >= vm.Adults.Count())
               && r.IsDeleted == false && Hotels.Any(h => h.Id == r.HotelId)).
              Include(r => r.Hotel).
              Include(r => r.RoomImages)
              .Include(r => r.RoomFeatures.Where(r=>r.IsDeleted==false)).
              ThenInclude(f => f.RoomFeaturesTranslation)
              .Include(r => r.RoomFeatures.Where(r => r.IsDeleted == false)).
              ThenInclude(f => f.RoomFeatureDetails).ThenInclude(r => r.RoomFeatureDetailTranslations)
                                                select r;
                if (availablerooms == null || availablerooms.Count() < 1)
                {
                    TempData["SearchRoomError"] = _localizer["No suitable rooms were found"].ToString();
                    
                    return View();
                };
                foreach (Hotel hotel in vm.Hotels)
                {
                    if (vm.Adults.Count==1)
                    {
                        hotel.Rooms = await availablerooms.Where(h => h.HotelId == hotel.Id && hotel.Name.ToLower().Contains("Double".ToLower()) == false).ToListAsync();
                        if (hotel.Rooms == null || hotel.Rooms.Count() < 1)
                        {
                            TempData["SearchRoomError"] = _localizer["No suitable rooms were found"].ToString();
                            return View();
                        };

                    }
                    else if (vm.Adults.Count == 2)
                    {
                        hotel.Rooms = await availablerooms.Where(h => h.HotelId == hotel.Id).ToListAsync();
                        if (hotel.Rooms == null || hotel.Rooms.Count() < 1)
                        {
                            TempData["SearchRoomError"] = _localizer["No suitable rooms were found"].ToString();
                            return View();
                        };
                    }
                };
            }
            else
            {
                IQueryable<RoomType> availablerooms = from r in _context.RoomTypes.
              Where
              (r => (r.People >= vm.Adults.Count()) && (r.Children >= vm.Childs.Count())
               && r.IsDeleted == false && Hotels.Any(h => h.Id == r.HotelId)).
              Include(r => r.Hotel).
              ThenInclude(h => h.HotelFeatures).
              ThenInclude(h => h.HotelFeatureDetails).
              Include(r => r.RoomImages)
              .Include(r => r.RoomFeatures.Where(r => r.IsDeleted == false)).
              ThenInclude(f => f.RoomFeaturesTranslation)
              .Include(r => r.RoomFeatures.Where(r => r.IsDeleted == false)).
              ThenInclude(f => f.RoomFeatureDetails).ThenInclude(r => r.RoomFeatureDetailTranslations)
                                                      select r;
                if (availablerooms == null || availablerooms.Count() < 1)
                {
                    TempData["SearchRoomError"] = _localizer["No suitable rooms were found"].ToString();
                    return View();
                };
                foreach (Hotel hotel in vm.Hotels)
                {
                    if (vm.Adults.Count == 1)
                    {
                        hotel.Rooms = await availablerooms.Where(h => h.HotelId == hotel.Id && hotel.Name.ToLower().Contains("Double".ToLower()) == false).ToListAsync();
                        if (hotel.Rooms == null || hotel.Rooms.Count() < 1)
                        {
                            TempData["SearchRoomError"] = _localizer["No suitable rooms were found"].ToString();
                            return View();
                        };

                    }
                    else if (vm.Adults.Count == 2)
                    {
                        hotel.Rooms =  await availablerooms.Where(h => h.HotelId == hotel.Id).ToListAsync();
                        if (hotel.Rooms == null || hotel.Rooms.Count() < 1)
                        {
                            TempData["SearchRoomError"] = _localizer["No suitable rooms were found"].ToString();
                            return View();
                        };
                    }
                 
                };
            }



            


            foreach (Hotel hotel in vm.Hotels)
            {
                if (hotel.Season != null && hotel.Season.LowSeason != null && hotel.Season.MidSeason != null && hotel.Season.HighSeason != null)
                {
                    vm.HighMonthvalues = new List<int>();
                    vm.LowMonthvalues = new List<int>();
                    vm.MidMonthvalues = new List<int>();

                    if (hotel.Season.LowSeason.January == true)
                    {
                        vm.LowMonthvalues.Add(1);
                    }
                    if (hotel.Season.LowSeason.February == true)
                    {
                        vm.LowMonthvalues.Add(2);
                    }
                    if (hotel.Season.LowSeason.March == true)
                    {
                        vm.LowMonthvalues.Add(3);
                    }
                    if (hotel.Season.LowSeason.April == true)
                    {
                        vm.LowMonthvalues.Add(4);
                    }
                    if (hotel.Season.LowSeason.May == true)
                    {
                        vm.LowMonthvalues.Add(5);
                    }
                    if (hotel.Season.LowSeason.June == true)
                    {
                        vm.LowMonthvalues.Add(6);
                    }
                    if (hotel.Season.LowSeason.July == true)
                    {
                        vm.LowMonthvalues.Add(7);
                    }
                    if (hotel.Season.LowSeason.August == true)
                    {
                        vm.LowMonthvalues.Add(8);
                    }
                    if (hotel.Season.LowSeason.September == true)
                    {
                        vm.LowMonthvalues.Add(9);
                    }
                    if (hotel.Season.LowSeason.October == true)
                    {
                        vm.LowMonthvalues.Add(10);
                    }
                    if (hotel.Season.LowSeason.November == true)
                    {
                        vm.LowMonthvalues.Add(11);
                    }
                    if (hotel.Season.LowSeason.December == true)
                    {
                        vm.LowMonthvalues.Add(12);
                    }
                    if (hotel.Season.MidSeason.January == true)
                    {
                        vm.MidMonthvalues.Add(1);
                    }
                    if (hotel.Season.MidSeason.February == true)
                    {
                        vm.MidMonthvalues.Add(2);
                    }
                    if (hotel.Season.MidSeason.March == true)
                    {
                        vm.MidMonthvalues.Add(3);
                    }
                    if (hotel.Season.MidSeason.April == true)
                    {
                        vm.MidMonthvalues.Add(4);
                    }
                    if (hotel.Season.MidSeason.May == true)
                    {
                        vm.MidMonthvalues.Add(5);
                    }
                    if (hotel.Season.MidSeason.June == true)
                    {
                        vm.MidMonthvalues.Add(6);
                    }
                    if (hotel.Season.MidSeason.July == true)
                    {
                        vm.MidMonthvalues.Add(7);
                    }
                    if (hotel.Season.MidSeason.August == true)
                    {
                        vm.MidMonthvalues.Add(8);
                    }
                    if (hotel.Season.MidSeason.September == true)
                    {
                        vm.MidMonthvalues.Add(9);
                    }
                    if (hotel.Season.MidSeason.October == true)
                    {
                        vm.MidMonthvalues.Add(10);
                    }
                    if (hotel.Season.MidSeason.November == true)
                    {
                        vm.MidMonthvalues.Add(11);
                    }
                    if (hotel.Season.MidSeason.December == true)
                    {
                        vm.MidMonthvalues.Add(12);
                    }
                    if (hotel.Season.HighSeason.January == true)
                    {
                        vm.HighMonthvalues.Add(1);
                    }
                    if (hotel.Season.HighSeason.February == true)
                    {
                        vm.HighMonthvalues.Add(2);
                    }
                    if (hotel.Season.HighSeason.March == true)
                    {
                        vm.HighMonthvalues.Add(3);
                    }
                    if (hotel.Season.HighSeason.April == true)
                    {
                        vm.HighMonthvalues.Add(4);
                    }
                    if (hotel.Season.HighSeason.May == true)
                    {
                        vm.HighMonthvalues.Add(5);
                    }
                    if (hotel.Season.HighSeason.June == true)
                    {
                        vm.HighMonthvalues.Add(6);
                    }
                    if (hotel.Season.HighSeason.July == true)
                    {
                        vm.HighMonthvalues.Add(7);
                    }
                    if (hotel.Season.HighSeason.August == true)
                    {
                        vm.HighMonthvalues.Add(8);
                    }
                    if (hotel.Season.HighSeason.September == true)
                    {
                        vm.HighMonthvalues.Add(9);
                    }
                    if (hotel.Season.HighSeason.October == true)
                    {
                        vm.HighMonthvalues.Add(10);
                    }
                    if (hotel.Season.HighSeason.November == true)
                    {
                        vm.HighMonthvalues.Add(11);
                    }
                    if (hotel.Season.HighSeason.December == true)
                    {
                        vm.HighMonthvalues.Add(12);
                    }

                    foreach (RoomType room in hotel.Rooms)
                    {


                        foreach (Adult adult in vm.Adults)
                        {



                            if (vm.Childs != null)
                            {

                                foreach (Child child in vm.Childs)
                                {

                                    if (hotel.Name.ToLower().Contains("Chenot".ToLower()))
                                    {
                                        if (child.Age <= 5)
                                        {


                                            child.Price = room.Hotel.ExtraPrice.BabyPrice;

                                        }
                                        else if (child.Age > 5 && child.Age <= 11)
                                        {

                                            child.Price = room.Hotel.ExtraPrice.ChildPrice;



                                        }
                                        else if (child.Age > 11)
                                        {


                                            child.Price = room.Hotel.ExtraPrice.YoungPrice;

                                        }
                                    }
                                    else
                                    {
                                        if (child.Treatment)
                                        {
                                            if (child.Age <= 5)
                                            {


                                                child.Price = room.Hotel.ExtraPrice.BabyPricewithtreatment;

                                            }
                                            else if (child.Age > 5 && child.Age <= 11)
                                            {

                                                child.Price = room.Hotel.ExtraPrice.ChildPricewithtreatment;



                                            }
                                            else if (child.Age > 11)
                                            {


                                                child.Price = room.Hotel.ExtraPrice.YoungPricewithtreatment;

                                            }
                                        }
                                        else
                                        {
                                            if (child.Age <= 5)
                                            {


                                                child.Price = room.Hotel.ExtraPrice.BabyPrice;

                                            }
                                            else if (child.Age > 5 && child.Age <= 11)
                                            {

                                                child.Price = room.Hotel.ExtraPrice.ChildPrice;



                                            }
                                            else if (child.Age > 11)
                                            {


                                                child.Price = room.Hotel.ExtraPrice.YoungPrice;

                                            }
                                        }
                                    }
                                  


                                }
                            }




                            if (room.SpecialDays != null && room.SpecialDays.Count() > 0)
                            {
                                foreach (SpecialDays specialDays in room.SpecialDays)
                                {
                                    if (vm.Checkin >= specialDays.Start && vm.Checkout <= specialDays.End && vm.Checkin <= vm.Checkout)
                                    {
                                        
                                        adult.Price = specialDays.Price / vm.Adults.Count;
                                    }
                                    else
                                    {
                                        if (Helpers.Extentions.Compare(vm.Checkout, vm.Checkin) <= 13 && Helpers.Extentions.Compare(vm.Checkout, vm.Checkin) >= 1)
                                        {


                                            foreach (int low in vm.LowMonthvalues)
                                            {
                                                foreach (int mid in vm.MidMonthvalues)
                                                {
                                                    foreach (int high in vm.HighMonthvalues)
                                                    {


                                                        if (vm.Checkin.Month == low)
                                                        {
                                                            adult.Price = room.OneweekPrice / vm.Adults.Count;

                                                        }

                                                        else if (vm.Checkin.Month == mid)
                                                        {

                                                            adult.Price = room.OneweekPriceMid / vm.Adults.Count;


                                                        }
                                                        else if (vm.Checkin.Month == high)
                                                        {
                                                            adult.Price = room.OneweekPriceHigh / vm.Adults.Count;
                                                        }



                                                    }
                                                }
                                            }







                                        }
                                        else if (Helpers.Extentions.Compare(vm.Checkout, vm.Checkin) <= 20 && Helpers.Extentions.Compare(vm.Checkout, vm.Checkin) >= 14)
                                        {



                                            foreach (int low in vm.LowMonthvalues)
                                            {
                                                foreach (int mid in vm.MidMonthvalues)
                                                {
                                                    foreach (int high in vm.HighMonthvalues)
                                                    {


                                                        if (vm.Checkin.Month == low)
                                                        {
                                                            adult.Price = room.TwoweeksPrice / vm.Adults.Count;

                                                        }

                                                        else if (vm.Checkin.Month == mid)
                                                        {

                                                            adult.Price = room.TwoweeksPriceMid / vm.Adults.Count;


                                                        }
                                                        else if (vm.Checkin.Month == high)
                                                        {
                                                            adult.Price = room.TwoweeksPriceHigh / vm.Adults.Count;
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        else if (Helpers.Extentions.Compare(vm.Checkout, vm.Checkin) >= 21)
                                        {


                                            foreach (int low in vm.LowMonthvalues)
                                            {
                                                foreach (int mid in vm.MidMonthvalues)
                                                {
                                                    foreach (int high in vm.HighMonthvalues)
                                                    {

                                                        if (vm.Checkin.Month == low)
                                                        {
                                                            adult.Price = room.ThreeweeksPrice / vm.Adults.Count;

                                                        }

                                                        else if (vm.Checkin.Month == mid)
                                                        {

                                                            adult.Price = room.ThreeweeksPriceMid / vm.Adults.Count;


                                                        }
                                                        else if (vm.Checkin.Month == high)
                                                        {
                                                            adult.Price = room.ThreeweeksPriceHigh / vm.Adults.Count;
                                                        }


                                                    }
                                                }
                                            }

                                        }
                                    }
                                }



                            }
                            else
                            {
                                if (Helpers.Extentions.Compare(vm.Checkout, vm.Checkin) <= 13 && Helpers.Extentions.Compare(vm.Checkout, vm.Checkin) >= 1)
                                {


                                    foreach (int low in vm.LowMonthvalues)
                                    {
                                        if (vm.Checkin.Month == low)
                                        {
                                            adult.Price = room.OneweekPrice / vm.Adults.Count;

                                        }
                                    }
                                    foreach (int mid in vm.MidMonthvalues)
                                    {

                                        if (vm.Checkin.Month == mid)
                                        {

                                            adult.Price = room.OneweekPriceMid / vm.Adults.Count;


                                        }
                                    }
                                        foreach (int high in vm.HighMonthvalues)
                                    {

                                   

                                        if (vm.Checkin.Month == high)
                                        {
                                            adult.Price = room.OneweekPriceHigh / vm.Adults.Count;
                                        }
                               
                                }
                            
                        







                    }
                                else if (Helpers.Extentions.Compare(vm.Checkout, vm.Checkin) <= 20 && Helpers.Extentions.Compare(vm.Checkout, vm.Checkin) >= 14)
                                {



                                    foreach (int low in vm.LowMonthvalues)
                                    {
                                        foreach (int mid in vm.MidMonthvalues)
                                        {
                                            foreach (int high in vm.HighMonthvalues)
                                            {


                                                if (vm.Checkin.Month == low)
                                                {
                                                    adult.Price = room.TwoweeksPrice / vm.Adults.Count;

                                                }

                                                else if (vm.Checkin.Month == mid)
                                                {

                                                    adult.Price = room.TwoweeksPriceMid / vm.Adults.Count;


                                                }
                                                else if (vm.Checkin.Month == high)
                                                {
                                                    adult.Price = room.TwoweeksPriceHigh / vm.Adults.Count;
                                                }
                                            }

                                        }
                                    }

                                }

                                else if (Helpers.Extentions.Compare(vm.Checkout, vm.Checkin) >= 21)
                                {


                                    foreach (int low in vm.LowMonthvalues)
                                    {
                                        foreach (int mid in vm.MidMonthvalues)
                                        {
                                            foreach (int high in vm.HighMonthvalues)
                                            {

                                                if (vm.Checkin.Month == low)
                                                {
                                                    adult.Price = room.ThreeweeksPrice / vm.Adults.Count;

                                                }

                                                else if (vm.Checkin.Month == mid)
                                                {

                                                    adult.Price = room.ThreeweeksPriceMid / vm.Adults.Count;


                                                }
                                                else if (vm.Checkin.Month == high)
                                                {
                                                    adult.Price = room.ThreeweeksPriceHigh / vm.Adults.Count;
                                                }


                                            }
                                        }
                                    }

                                }
                            }

                            





                            if (vm.Childs != null)
                            {
                                room.TotalPrice = (vm.Adults.Sum(p => p.Price) + vm.Childs.Sum(p => p.Price)) * Helpers.Extentions.Compare(vm.Checkout, vm.Checkin);
                            }
                            else
                            {
                                room.TotalPrice = vm.Adults.Sum(p => p.Price) * Helpers.Extentions.Compare(vm.Checkout, vm.Checkin);


                            }
                        }
                    }

                }
            }


            TempData["CheckinDate"] = vm.Checkin.AddHours(+14);
            TempData["CheckoutDate"] = vm.Checkout.AddHours(+12);



            

            await _context.SaveChangesAsync();

            
            return View(vm);
        }
        public async Task<IActionResult> AddAdult()
        {

            Adult model = new Adult
            {
                Id = Guid.NewGuid()
            };





            return PartialView("_AddAdult", model);
        }







        public async Task<IActionResult> AddChild()
        {

            Child model = new Child();



            return PartialView("_AddChild", model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendComment(int Id, SearchRoomVM riview)
        {
            Review comment = new Review
            {
                HotelId = Id,
                Email = riview.Reviews.Email,
                Text = riview.Reviews.Text,
                UserName = riview.Reviews.UserName,
                Date = DateTime.UtcNow.AddHours(+4)
            };
            comment.AppUserId = (User.Identity.IsAuthenticated) ? (await _usermanager.FindByNameAsync(User.Identity.Name)).Id : null;
            await _context.Reviews.AddAsync(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
