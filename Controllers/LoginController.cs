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
            // Agregar sessions para tener control
            // Trabajar ecepciones para que no estén vacios, y el email sea valido, además que el username no se repita
            string username = Request.Form["Username"];
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            // Validar si existe, si no guardar y crear usuario y mostrar mensaje de usuario creado
            var existingUser = _context.Usuarios.FirstOrDefault(user => user.UserMail == email);

            if (existingUser != null)
            {
                // Mandar mensaje de que ya existe una cuenta asociada a ese correo
                // return View("~/Views/Login");
                ViewData["ErrorMessage"] = "Ya existe una cuenta asociada a ese correo.";
                return View("Index");
            }
            else
            {
                // El correo no existe en la base de datos, crear usurario
                var newUser = new Usuario
                {
                    UserMail = email,
                    UserName = username,
                    Password = password,
                };

                // Guardar el nuevo usuario en la base de datos
                _context.Usuarios.Add(newUser);
                _context.SaveChanges();

                // Guardar el ID del usuario en la sesión
                HttpContext.Session.SetInt32("UserId", newUser.UserId);

                // Mostrar perfil
                // return View("~/Views/Prueba/Index.cshtml");
                return RedirectToAction("Profile", "Home");
            }
        }

        [HttpPost]
        public ActionResult SignIn()
        {
            // Agregar sessions para tener control
            // Trabajar ecepciones para que no estén vacios
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            

            // Validar si existe usuario 
            var user = _context.Usuarios.FirstOrDefault(user => user.UserMail == email && user.Password == password);

            if (user != null)
            {
                // Usuario válido, redirigir a la pagina del perfil, además de ir mandando su id o algo para identificarlo en las vistas siguientes(Quizas sean sessions)
                // return View("~/Views/Prueba/Index.cshtml");

                // Guardar el ID del usuario en la sesión
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("Profile", "Home");
            }
            else
            {
                // si no enviar mensaje de error por que no existe ese usuario o los datos son incorrectos
                // return View("~/Views/Login");
                ViewData["ErrorMessage"] = "Credenciales incorrectas.";
                return View("Index");
            }
        }
    }
}
