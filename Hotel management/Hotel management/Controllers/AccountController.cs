using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using Hotel_management.Models;
using Hotel_management.ViewModels.AccountViewModel;
using Microsoft.Extensions.Localization;

namespace Hotel_management.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _manager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _env;
        private readonly IStringLocalizer<SharedResource> _localizer;


        public AccountController(IWebHostEnvironment env, UserManager<AppUser> manager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IStringLocalizer<SharedResource> localizer)
        {
            _manager = manager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _env = env;
            _localizer = localizer;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
                return NotFound();

            AppUser appUser = await _manager.FindByEmailAsync(loginVM.Email);

            if (appUser == null)
            {
                ModelState.AddModelError("", $"{_localizer["Email or password is incorrect"]}");
                return View(loginVM);
            }

            if (appUser.EmailConfirmed == false)
            {
                ModelState.AddModelError("", $"{_localizer["Your email has not been verified"]}");
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult signinResult = await _signInManager
                .PasswordSignInAsync(appUser, loginVM.Password, true, true);

            if (signinResult.IsLockedOut)
            {
                ModelState.AddModelError("", $"{_localizer["Your email has been blocked"]}");
                return View(loginVM);
            }

            if (!signinResult.Succeeded)
            {
                ModelState.AddModelError("", $"{_localizer["Email or password is incorrect"]}");
                return View(loginVM);
            }

            if ((await _manager.GetRolesAsync(appUser))[0] == "Admin")
            {
                return RedirectToAction("Dashboard", "Manage");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            AppUser appUser = new AppUser
            {
                Name = registerVM.Name,
                SurName = registerVM.SurName,
                Email = registerVM.Email,
                UserName = registerVM.UserName,
                
            };

            IdentityResult identityResult = await _manager.CreateAsync(appUser, registerVM.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError identityError in identityResult.Errors)
                {
                    ModelState.AddModelError(identityError.Code, identityError.Description);
                }
                return View(registerVM);
            }

          

            // create email message

            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("info@htn.az"));
            message.To.Add(MailboxAddress.Parse(appUser.Email));
            message.Subject = _localizer["Confirmation Email"];
            message.Body = new TextPart(TextFormat.Plain) { Text = $"Health Tour  {_localizer["Confirmation Email"]}" };
            string emailbody = string.Empty;

            using (StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "Templates", "Emailconfirm.html")))
            {
                emailbody = streamReader.ReadToEnd();
            }

            string emailconfirmtoken = await _manager.GenerateEmailConfirmationTokenAsync(appUser);

            string url = Url.Action("Confirmemail", "Account", new { id = appUser.Id, token = emailconfirmtoken }, Request.Scheme);

            emailbody = emailbody.Replace("{{Fullname}}", $"{ appUser.Name} {appUser.SurName }").Replace("{{url}}", $"{url}");

            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("mail.htn.az", 587, SecureSocketOptions.None);
            smtp.Authenticate("info@htn.az", "Hotel0202@");
            smtp.Send(message);
            smtp.Disconnect(true);
            await _manager.AddToRoleAsync(appUser, "Member");
            await _signInManager.SignInAsync(appUser, true);

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Confirmemail(string id, string token)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(token))
            {
                return NotFound();
            }
            AppUser appUser = await _manager.FindByIdAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            IdentityResult identityResult = await _manager.ConfirmEmailAsync(appUser, token);
            if (!identityResult.Succeeded)
            {
                return NotFound();
            }
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return NotFound();
            }

            AppUser appUser = await _manager.FindByEmailAsync(email);

            if (appUser == null)
            {
                return NotFound();
            }
            var message = new MimeMessage();
       
            message.From.Add(MailboxAddress.Parse("info@htn.az"));
            message.To.Add(MailboxAddress.Parse(appUser.Email));
            message.Subject = _localizer["Change Password"];
            message.Body = new TextPart(TextFormat.Plain) { Text = $"Health Tour {_localizer["Reset"]} {_localizer["Password"]}" };
            string emailbody = string.Empty;

            using (StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "Templates", "Forgotpassword.html")))
            {
                emailbody = streamReader.ReadToEnd();
            }

            string passwordconfirmtoken = await _manager.GeneratePasswordResetTokenAsync(appUser);
            string url = Url.Action("Changepassword", "Account", new { id = appUser.Id, token = passwordconfirmtoken }, Request.Scheme);

            emailbody = emailbody.Replace("{{Fullname}}", $"{ appUser.Name} {appUser.SurName }").Replace("{{url}}", $"{url}");

            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("mail.htn.az", 587, SecureSocketOptions.None);
            smtp.Authenticate("info@htn.az", "Hotel0202@");
            smtp.Send(message);
            smtp.Disconnect(true);
            return View();
        }

        public async Task<IActionResult> Changepassword(string id, string token)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(token))
            {
                return NotFound();
            }

            AppUser appUser = await _manager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            ResetpasswordVM resetpasswordVM = new ResetpasswordVM
            {
                Id = id,
                Token = token,
            };

            return View(resetpasswordVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Changepassword(ResetpasswordVM resetpasswordVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrWhiteSpace(resetpasswordVM.Id) || string.IsNullOrWhiteSpace(resetpasswordVM.Token))
            {
                return NotFound();
            }

            AppUser appUser = await _manager.FindByIdAsync(resetpasswordVM.Id);

            if (appUser == null)
            {
                return NotFound();
            }

            IdentityResult identityResult = await _manager.ResetPasswordAsync(appUser, resetpasswordVM.Token, resetpasswordVM.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(resetpasswordVM);
            }

            return RedirectToAction("Login");
        }

        #region Add Role

        //public async Task<IActionResult> AddRole()
        //{
        //    if (!await _roleManager.RoleExistsAsync("Admin"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    }
        //    if (!await _roleManager.RoleExistsAsync("Member"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
        //    }
           

        //    return Content("Role Yarandi");
        //}
        #endregion

    }

}
