using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Wave.Models;

namespace Wave.Controllers
{
    public class UserController : Controller
    {
        private readonly WaveDbContext _context;

        public UserController(WaveDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Search(string searchTerm)
        {
            var users = await _context.Usuarios
                .Where(u => u.UserName.Contains(""))
                .ToListAsync();

            return View("SearchResults", users);
        }

        // Vista para mostrar los resultados de la búsqueda
        public IActionResult SearchResults(List<Usuario> users)
        {
            return View(users);
        }

        public async Task<IActionResult> Profile(int? otheruser)
        {
            ViewBag.OtherUser = otheruser;
            return View(await _context.Posts.ToListAsync());
        }
    }
}
