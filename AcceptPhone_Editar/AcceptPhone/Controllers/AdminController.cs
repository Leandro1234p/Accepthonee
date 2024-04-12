using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcceptPhone.Models;

namespace AcceptPhone.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Administrador")]
        public ActionResult AdminDashboard()
        {
            // Verificar si el usuario autenticado es "admin@gmail.com"
            if (User.Identity.IsAuthenticated && User.Identity.Name.Equals("admin@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                // Puedes pasar directamente los datos a la vista usando un modelo o ViewBag
                return View();
            }
            else
            {
                // Si el usuario no es "admin@gmail.com", redirige al índice de la aplicación
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpGet]
        public ActionResult ListarUsuarios()
        {
            // Lógica para obtener y mostrar la lista de usuarios
            return View();
        }
        [HttpGet]
        public ActionResult EditarUsuario(int? id)
        {
            // Lógica para editar el usuario con el ID proporcionado
            if (id == null)
            {
                // Manejar el caso en que id es nulo
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();

        }
    }
}
