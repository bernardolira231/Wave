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
            // Trabajar ecepciones para que no estén vacios, y el email sea valido, además que el username no se repita
            string username = Request.Form["Username"];
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            // Validar si existe, si no guardar y crear usuario y mostrar mensaje de usuario creado, si si, mandar mensaje de que ya existe una cuenta asociada a ese correo


            return null; // O redirigir a otra vista, etc.
        }

        [HttpPost]
        public ActionResult SignIn()
        {
            // Trabajar ecepciones para que no estén vacios
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            // Validar si existe usuario, si si, redirigiir a la pagina del perfil
            return View("~/Views/Home/Index.cshtml");

            // si no enviar mensaje de error por que no existe ese usuario
        }
    }
}
