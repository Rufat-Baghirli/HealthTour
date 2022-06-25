using Hotel_management.DAL;
using Hotel_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Text;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel_management.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IStringLocalizer<SharedResource> _localizer;


        public ReservationController(AppDbContext context, IWebHostEnvironment env, IStringLocalizer<SharedResource> localizer)
        {

            _context = context;
            _env = env;
            _localizer = localizer;
        }
        public async Task<IActionResult> Reserve(int? Id, int adult, int Child, double Totalprice)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Room room = await _context.Rooms.Include(r => r.Hotel).ThenInclude(h => h.HotelStar).Include(r => r.Hotel).ThenInclude(r => r.Treatments).Include(r => r.RoomType).FirstOrDefaultAsync(r => r.Id == Id);

            if (room == null)
            {
                return BadRequest();

            }

            List<Adult> newAdults = new List<Adult>();

            Booking booking = new Booking
            {

                Adult = adult,
                Child = Child,
                Checkin = (DateTime)TempData["CheckinDate"],
                Checkout = (DateTime)TempData["CheckoutDate"],
                Email = null,
                Guest = adult + Child,
                Hotel = room.Hotel,
                RoomId = room.Id,
                Room = room,
                Name = null,
                Night = Helpers.Extentions.Compare((DateTime)TempData["CheckoutDate"], (DateTime)TempData["CheckinDate"]) + 1,
                ReserveTime = DateTime.Now,
                PhoneNumber = null,
                SurName = null,
                TotalPrice = Totalprice,
                Ordernumber = null,
                IsDeleted = true


            };

          

            for (int i = 0; i < adult; i++)
            {

                try
                {


                 Adult adult0 =  new Adult
                    {

                        Id = (Guid)TempData[$"AdultsGuid{i}"],
                        Price = (double)TempData[$"AdultsPrice{i}"],
                        Treatment = (bool)TempData[$"AdultsTreatment{i}"],
                    };
                    
                    if (await _context.Adults.FirstOrDefaultAsync(c => c.Id == adult0.Id) == null)
                        newAdults.Add(adult0);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            booking.Adults = newAdults;

            if (Child > 0)
            {
                List<Child> newChilds = new List<Child>();
                for (int i = 0; i < Child; i++)
                {
                    Child child = new Child
                    {

                        Id = (Guid)TempData[$"ChildsGuid{i}"],
                        Price = (double)TempData[$"ChildsPrice{i}"],
                        Age = (int)TempData[$"Age{i}"],
                        Treatment = (bool)TempData[$"ChildrenTreatment{i}"],
                    };
                    if( await _context.Children.FirstOrDefaultAsync(c=>c.Id== child.Id) == null)
                        newChilds.Add(child);
                }

                booking.Children = newChilds;
                await _context.Children.AddRangeAsync(booking.Children);
            }



            await _context.Bookings.AddAsync(booking);
            await _context.Adults.AddRangeAsync(booking.Adults);
            await _context.SaveChangesAsync();
            TempData["BookingId"] = booking.Id;
            TempData.Keep();

            return View(booking);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reserve(Booking booking, string PhoneNumber, string Email, string Name, string SurName)
        {


            if (TempData["BookingId"] == null)
            {
                return NotFound();
            }

            
            Booking dBbooking = await _context.Bookings.Include(b => b.Adults).FirstOrDefaultAsync(b => b.Id == (int)TempData["BookingId"]);
            dBbooking.Room = await _context.Rooms.Include(r => r.RoomType).Include(r => r.Hotel).ThenInclude(h => h.Location).Include(r => r.Hotel).ThenInclude(r => r.Treatments).FirstOrDefaultAsync(b => b.Id == dBbooking.RoomId);
            dBbooking.Ordernumber = $"Ord-0000-{dBbooking.Id}";



            if (booking == null)
            {
                return BadRequest();
            }

            if (dBbooking.Hotel.Name.ToLower().Contains("Chenot".ToLower()))
            {
                for (int i = 0; i < dBbooking.Adults.Where(a => a.Treatment).Count(); i++)
                {
                    dBbooking.Adults.Where(a => a.Treatment).ElementAt(i).Treatment_modelId = booking.AdultsItems[i];
                    dBbooking.Adults.Where(a => a.Treatment).ElementAt(i).Treatment_model = await _context.Treatments.FirstOrDefaultAsync(t => t.Id == booking.AdultsItems[i]);
                    dBbooking.Adults.Where(a => a.Treatment).ElementAt(i).Price = dBbooking.Adults.Where(a => a.Treatment).ElementAt(i).Treatment_model.Price + dBbooking.Adults.Where(a => a.Treatment).ElementAt(i).Price;


                }

                if (dBbooking.Child > 0)
                {
                    for (int i = 0; i < dBbooking.Children.Where(a => a.Treatment).Count(); i++)
                    {
                        dBbooking.Children.Where(a => a.Treatment).ElementAt(i).Treatment_modelId = booking.ChildrenItems[i];
                        dBbooking.Children.Where(a => a.Treatment).ElementAt(i).Treatment_model = await _context.Treatments.FirstOrDefaultAsync(t => t.Id == booking.ChildrenItems[i]);
                        dBbooking.Children.Where(a => a.Treatment).ElementAt(i).Price = dBbooking.Children.Where(a => a.Treatment).ElementAt(i).Treatment_model.Price + dBbooking.Children.Where(a => a.Treatment).ElementAt(i).Price;


                    }

                }
            }
          

            dBbooking.Name = Name;
            dBbooking.SurName = SurName;
            dBbooking.Email = Email;
            dBbooking.PhoneNumber = PhoneNumber;
            dBbooking.IsDeleted = false;
            if(dBbooking.Child < 1)
            {
                dBbooking.TotalPrice = dBbooking.Adults.Sum(t => t.Price) * dBbooking.Night;
            }
            else
            {
                dBbooking.TotalPrice = (dBbooking.Adults.Sum(t => t.Price) + dBbooking.Children.Sum(c => c.Price)) * dBbooking.Night;

            }
            double dailyprice = dBbooking.TotalPrice / dBbooking.Night;

            await _context.SaveChangesAsync();


            TempData["Reserve"] = _localizer["Your reservation information will be sent to your email"].ToString();
            TempData.Keep();

            MimeMessage message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("office@htn.az"));
            if (Email != null)
            {
                message.To.Add(MailboxAddress.Parse(Email)); message.Subject = _localizer["Reservation"];
                message.Body = new TextPart(TextFormat.Plain) { Text = _localizer["Reservation Information"] };
                string emailbody = string.Empty;

                using (StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "Templates", "Booking.html")))
                {
                    emailbody = streamReader.ReadToEnd();
                }

                emailbody = emailbody.Replace("{{User Name}}", $"{Name} {SurName}").Replace("{{BOOKING-CODE}}", $"{dBbooking.Ordernumber}").
                    Replace("{{Hotel Name}}", $"{dBbooking.Room.Hotel.Name}").Replace("{{Room Type Name}}", $"{dBbooking.Room.RoomType.Name}").Replace("{{Total Guests}}", $"{dBbooking.Guest}").
                    Replace("{{Checkin}}", $"{dBbooking.Checkin}").Replace("{{Checkout}}", $"{dBbooking.Checkout}").Replace("{{Mobile}}", $"{dBbooking.PhoneNumber}").Replace("{{Price}}", $"{dailyprice}").
                    Replace("{{night}}", $"{dBbooking.Night}").Replace("{{TotalPrice}}", $"{dBbooking.TotalPrice}").Replace("{{City}}", $"{dBbooking.Room.Hotel.Location.City}")
                    .Replace("{{Adults}}", $"{dBbooking.Adult}").Replace("{{Children}}", $"{dBbooking.Child}");

                message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

                // send email
                using SmtpClient smtp = new SmtpClient();
                smtp.Connect("mail.htn.az", 587, SecureSocketOptions.None);
                smtp.Authenticate("office@htn.az", "Hotel0202@");
                smtp.Send(message);
                smtp.Disconnect(true);

                MimeMessage reservationmessage = new MimeMessage();
                reservationmessage.From.Add(MailboxAddress.Parse("info@htn.az"));
                reservationmessage.To.Add(MailboxAddress.Parse("office@htn.az"));
                reservationmessage.Subject = _localizer["Rezervasiya"];
                reservationmessage.Body = new TextPart(TextFormat.Plain) { Text = "İstifadəçi rezervasiya məlumatları" };
                string emailbody2 = string.Empty;

                using (StreamReader streamReader2 = new StreamReader(Path.Combine(_env.WebRootPath, "Templates", "Booking.html")))
                {
                    emailbody2 = streamReader2.ReadToEnd();
                }




                emailbody2 = emailbody2.Replace("{{User Name}}", $"{Name} {SurName}").Replace("{{BOOKING-CODE}}", $"{dBbooking.Ordernumber}").
                    Replace("{{Hotel Name}}", $"{dBbooking.Room.Hotel.Name}").Replace("{{Room Type Name}}", $"{dBbooking.Room.RoomType.Name}").Replace("{{Total Guests}}", $"{dBbooking.Guest}").
                    Replace("{{Checkin}}", $"{dBbooking.Checkin}").Replace("{{Checkout}}", $"{dBbooking.Checkout}").Replace("{{Mobile}}", $"{dBbooking.PhoneNumber}").Replace("{{Price}}", $"{dailyprice}").
                    Replace("{{night}}", $"{dBbooking.Night}").Replace("{{TotalPrice}}", $"{dBbooking.TotalPrice}").Replace("{{City}}", $"{dBbooking.Room.Hotel.Location.City}")
                    .Replace("{{Adults}}", $"{dBbooking.Adult}").Replace("{{Children}}", $"{dBbooking.Child}");

                reservationmessage.Body = new TextPart(TextFormat.Html) { Text = emailbody };

                // send email
                using SmtpClient smtp2 = new SmtpClient();
                smtp.Connect("mail.htn.az", 587, SecureSocketOptions.None);
                smtp.Authenticate("info@htn.az", "Hotel0202@");
                smtp.Send(message);
                smtp.Disconnect(true);
            }
            

            return RedirectToAction("Index", "Home");
        }



       


    }


}

