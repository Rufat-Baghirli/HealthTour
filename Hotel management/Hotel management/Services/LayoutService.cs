using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Hotel_management.Models;
using Hotel_management.ViewModels.AccountViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_management.DAL;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Services
{
    public class LayoutService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;


        public LayoutService(IHttpContextAccessor httpContext, UserManager<AppUser> userManager, AppDbContext context)
        {
            _httpContext = httpContext;
            _userManager = userManager;
            _context = context;
        }

        public async Task<AppUserVM> GetUser()
        {
            AppUserVM appUserVM = null;
           

            if (_httpContext.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.FindByNameAsync(_httpContext.HttpContext.User.Identity.Name);

                appUserVM = new AppUserVM
                {
                    Name = appUser.Name,
                    SurName = appUser.SurName
                };
            }

            return appUserVM;
        }

      public async Task<HealthTourContact> GetContact()
        {
            return await _context.HealthTourContacts.FirstOrDefaultAsync();
        }
    }
}
