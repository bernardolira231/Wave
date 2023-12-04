using Microsoft.EntityFrameworkCore;
using Wave.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Inyección de dependencia
// Parte del pricipio SOLID
builder.Services.AddDbContext<WaveDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WaveDbContext"));
});

// Servicios de sessions
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication("Cookies").AddCookie();
// Fin servicios de session

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Middleware de sessions
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
// fin de middleware de sessions

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
