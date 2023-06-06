using EvaraWebApp.Controllers;
using EvaraWebApp.DataContext;
using EvaraWebApp.Models;
using EvaraWebApp.Services.Abstracts;
using EvaraWebApp.Services.Concrets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Singleton - Program run olarken sadece bir object yaradir.
//Scoped - Hər request yeni bir object yaradır
//Transient - Hər müraciətdə yeni bir object yaradır


builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequiredLength = 8;
    opt.Password.RequiredUniqueChars = 3;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireNonAlphanumeric = false;

    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedEmail = true;
})
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<EvaraDbContext>();

builder.Services.AddDbContext<EvaraDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddSession(cfg => cfg.IdleTimeout = TimeSpan.FromMinutes(5));

builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
