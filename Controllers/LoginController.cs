﻿using Microsoft.AspNetCore.Mvc;
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

            // Validar si existe, si no guardar y crear usuario y mostrar mensaje de usuario creado
            var existingUser = _context.Usuarios.FirstOrDefault(user => user.UserMail == email);

            if (existingUser != null)
            {
                // Mandar mensaje de que ya existe una cuenta asociada a ese correo
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

                // Mostrar perfil
                return View("~/Views/Prueba/Index.cshtml");
            }

            return null;
        }

        [HttpPost]
        public ActionResult SignIn()
        {
            // Trabajar ecepciones para que no estén vacios
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            

            // Validar si existe usuario 
            var user = _context.Usuarios.FirstOrDefault(user => user.UserMail == email && user.Password == password);

            if (user != null)
            {
                // Usuario válido, redirigiir a la pagina del perfil, además de ir mandando su id o algo para identificarlo en las vistas siguientes
                return View("~/Views/Prueba/Index.cshtml");
            }
            else
            {
                // si no enviar mensaje de error por que no existe ese usuario o los datos son incorrectos
            }

            return null;
        }
    }
}
