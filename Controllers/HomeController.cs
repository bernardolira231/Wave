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
    public string SavePost(IFormFile image, string title, string description)
    {

        string fileName = Path.GetFileName(image.FileName);

        var FileDic = "Files"; //carpeta donde se guardaran las imagenes

        string FilePath = Path.Combine(_environment.WebRootPath, FileDic); //hace la string de la ruta de carpeta

        if (!Directory.Exists(FilePath))
            Directory.CreateDirectory(FilePath); //si no existe la carpeta indicada la crea

        var filePath = Path.Combine(FilePath, image.FileName); //hace la string de la ruta para la imagen

        using (FileStream fs = System.IO.File.Create(filePath))
        {
            image.CopyTo(fs); //guarda la imagen
        }

        return "Saved file: " + fileName + " " + title + " " + description;
        //return View("Profile");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult LogOut()
    {
        // Limpiar la sesión al realizar logout
        HttpContext.Session.Clear();

        // Redirigir a la página de inicio u otra página después del logout
        return RedirectToAction("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
