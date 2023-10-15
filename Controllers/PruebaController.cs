using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wave.Models;

namespace Wave.Controllers
{
    public class PruebaController : Controller
    {
        private readonly WaveDbContext _context;

        public PruebaController(WaveDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() => View(await _context.Usuarios.ToListAsync());
    }
}
