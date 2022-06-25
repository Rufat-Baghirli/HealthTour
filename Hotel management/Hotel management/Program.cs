using Hotel_management.DAL;
using Hotel_management.Models;
using Hotel_management.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Reflection;
using Hotel_management;
using Microsoft.AspNetCore.Localization.Routing;
using Hotel_management.Controllers;
//using Hotel_management.Resources;
//using Hotel_management.Resources;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});
builder.Services.AddControllersWithViews().AddViewLocalization().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


builder.Services.AddMvc().
    AddViewLocalization().
    AddDataAnnotationsLocalization(
    options => options.DataAnnotationLocalizerProvider = (type, factory) =>
    {
        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
        return factory.Create(nameof(SharedResource),assemblyName.Name);
    }
    );

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new("az");
        
    CultureInfo[] cultures = new CultureInfo[]
    {
        new("az"),
        new("en"),
        new("ru")
    };

    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
    options.SupportedUICultures = cultures;
    options.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider (),
        new CookieRequestCultureProvider(),
        new AcceptLanguageHeaderRequestCultureProvider()
    };
   
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddScoped<LayoutService>();

builder.Services.AddIdentity<AppUser, IdentityRole>(identityOptions =>
{
    identityOptions.Password.RequireDigit = true;
    identityOptions.Password.RequiredLength = 8;
    identityOptions.Password.RequireLowercase = true;
    identityOptions.Password.RequireNonAlphanumeric = true;
    identityOptions.Password.RequireUppercase = true;
    identityOptions.Password.RequiredUniqueChars = 1;

    identityOptions.User.RequireUniqueEmail = true;

    identityOptions.Lockout.MaxFailedAccessAttempts = 3;
    identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    identityOptions.Lockout.AllowedForNewUsers = true;
}).AddDefaultTokenProviders()
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddHttpContextAccessor();
WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

}

else
{

    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
  
});




app.Run();
