using Microsoft.AspNetCore.Mvc;
using Wave.Models;

namespace Wave.Controllers
{
    public class LoginController : Controller
    {
        private readonly WaveDbContext _context;

        public LoginController(WaveDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp()
        {
            string username = Request.Form["Username"];
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            // Validar si existe, si no guardar y crear usuario y mostrar mensaje de usurio creado, si si, mandar mensaje de que ya existe una cuenta asociada a ese correo


            return View(); // O redirigir a otra vista, etc.
        }

        [HttpPost]
        public ActionResult SignIn()
        {
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            // Validar si existe usuario, si si, redirigiir a la pagina del perfil
            return View();

            // si no enviar mensaje de error por que no existe ese usuario
        }
    }
}
