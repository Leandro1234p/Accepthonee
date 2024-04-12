using AcceptPhone.Models;
using AcceptPhone.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace AcceptPhone.Controllers
{
    public class AccountController : Controller
    {
        // Acción para mostrar el formulario de registro
        public ActionResult Register()
        {
            return View();
        }



        // Acción para procesar el formulario de registro
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AccountRepository accountRepository = new AccountRepository();
                int result = accountRepository.Register(model);

                if (result > 0)
                {
                    // Guardar el nombre del usuario en TempData
                    TempData["RegisteredUsername"] = model.Username;

                    //Redirige al usuario a la vista Confirmation
                    return RedirectToAction("Confirmation", "Account");
                }
                else
                {
                    // Muestra un mensaje de error al usuario
                    ModelState.AddModelError(string.Empty, "El registro falló. Por favor, inténtalo nuevamente.");
                }
            }

            // Si el modelo no es válido, muestra el formulario de registro nuevamente con errores
            return View(model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                AccountRepository accountRepository = new AccountRepository();
                var user = accountRepository.login(model.Email, model.Password);

                if (user)
                {
                    await InitOwin(model);

                    if (model.Email.Equals("admin@gmail.com", StringComparison.OrdinalIgnoreCase))
                    {
                        System.Diagnostics.Debug.WriteLine("Redirigiendo a WelcomeAdmin");
                        // Redirige al administrador a una vista específica
                        return RedirectToAction("WelcomeAdmin", "Account");
                    }

                    TempData["SuccessMessage"] = "Conectado correctamente";
                    return RedirectToAction("Welcome");
                }
                else
                {
                    TempData["ErrorMessage"] = "Usuario No Encontrado";
                    return RedirectToAction("Login");
                }
            }

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        private async Task InitOwin(LoginViewModel model)
        {
            var claims = new[]
            {

                new Claim(ClaimTypes.Name, model.Email),
                new Claim("Email", model.Email)

            };

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignIn(identity);


        }
        public ActionResult WelcomeAdmin()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            // Si el usuario no está autenticado, redirige a una página de inicio de sesión o realiza alguna otra acción.
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Welcome()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            // Si el usuario no está autenticado, redirige a una página de inicio de sesión o realiza alguna otra acción.
            return RedirectToAction("Login", "Account");

        }

        public ActionResult Confirmation()
        {
            // Recuperar el nombre del usuario de TempData
            string registeredUsername = TempData["RegisteredUsername"] as string;

            // Lógica adicional si es necesario...

            // Pasar el nombre del usuario a la vista
            ViewBag.RegisteredUsername = registeredUsername;
            // Lógica para recuperar los datos del usuario registrado
            RegisterViewModel model = new RegisterViewModel
            {
                Username = "NombreDelUsuario",
                Email = "CorreoElectronicoDelUsuario"
            };

            return View(model);
        }

        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Login", "Account");
        }
        public ActionResult ListarUsuarios()
        {
            var usuarios = ObtenerUsuariosRegistrados(); // Utiliza tu lógica para obtener los usuarios
            return View(usuarios);
        }

        private IEnumerable<RegisterViewModel> ObtenerUsuariosRegistrados()
        {
            
            var usuarios = new List<RegisterViewModel>
    {
        new RegisterViewModel { Username = "Usuario1", Email = "usuario1@gmail.com" },
        new RegisterViewModel { Username = "Usuario2", Email = "usuario2@gmail.com" },
        
    };

            return usuarios;
        }
        

    }
}

