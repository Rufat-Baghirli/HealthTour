using Hotel_management.DAL;
using Hotel_management.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace Hotel_management.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ContactController(AppDbContext context, IWebHostEnvironment env)
        {

            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task <IActionResult> SendMessage()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(Contact contact)
        {
            if (!ModelState.IsValid)

                return View(contact);

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("info@htn.az"));
            message.To.Add(MailboxAddress.Parse(contact.Email));
            message.Subject = "Health Tour";
            message.Body = new TextPart(TextFormat.Plain) { Text = "Health Tour Email" };
            string emailbody = string.Empty;

            using (StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "Templates", "Contact.html")))
            {
                emailbody = streamReader.ReadToEnd();
            }




            emailbody = emailbody.Replace("{{User Name}}", $"{contact.FirstName} {contact.LastName }").Replace("{{Email}}", $"{contact.Email}").
                Replace("{{City}}", $"{contact.City}").Replace("{{Description}}", $"{contact.Description}").
                Replace("{{Phone}}", $"{contact.Phone}");

            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("mail.htn.az", 587, SecureSocketOptions.None);
            smtp.Authenticate("info@htn.az", "Hotel0202@");
            smtp.Send(message);
            smtp.Disconnect(true);

            var usermessage = new MimeMessage();
            usermessage.From.Add(MailboxAddress.Parse("info@htn.az"));
            usermessage.To.Add(MailboxAddress.Parse("info@htn.az"));
            usermessage.Subject = "healthtour.az user message";
            usermessage.Body = new TextPart(TextFormat.Plain) { Text = "User Contact Message" };
            string useremailbody = string.Empty;

            using (StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "Templates", "ContactSite.html")))
            {
                useremailbody = streamReader.ReadToEnd();
            }




            useremailbody = useremailbody.Replace("{{User Name}}", $"{contact.FirstName} {contact.LastName }").Replace("{{Email}}", $"{contact.Email}").
                Replace("{{City}}", $"{contact.City}").Replace("{{Description}}", $"{contact.Description}").
                Replace("{{Phone}}", $"{contact.Phone}");

            usermessage.Body = new TextPart(TextFormat.Html) { Text = useremailbody };

            // send email
            using var usersmtp = new SmtpClient();
            smtp.Connect("mail.htn.az", 587, SecureSocketOptions.None);
            smtp.Authenticate("info@htn.az", "Hotel0202@");
            smtp.Send(usermessage);
            smtp.Disconnect(true);
            return RedirectToAction("Index","Home");
        }
    }
}
