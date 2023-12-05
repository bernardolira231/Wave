using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wave.Models;

namespace Wave.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly WaveDbContext _context;
    private IWebHostEnvironment _environment;

    public HomeController(ILogger<HomeController> logger, WaveDbContext context, IWebHostEnvironment environment)
    {
        _logger = logger;
        _context = context;
        _environment = environment;
    }

    public async Task<IActionResult> Profile() => View(await _context.Posts.ToListAsync());

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Search()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SavePost(IFormFile image, string title, string description)
    {
        // Obtén el usuario actual desde la sesión
        int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

        // Convierte la imagen a un array de bytes
        byte[] content;
        using (MemoryStream ms = new MemoryStream())
        {
            image.CopyTo(ms);
            content = ms.ToArray();
        }

        // Crea un nuevo objeto Post
        var newPost = new Post
        {
            UserId = userId,
            Likes = 0,
            PublicationDate = DateTime.Now,
            IsDeleted = false,
            Content = content,
            Caption = description
        };

        // Guarda el nuevo Post en la base de datos
        _context.Posts.Add(newPost);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult LogOut()
    {
        // Limpiar la variable de session y rediriir al index 
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
