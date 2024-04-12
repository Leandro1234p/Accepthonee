using AcceptPhone.Models;
using AcceptPhone.Repositories;
using System;
using System.Web.Mvc;

namespace AcceptPhone.Controllers
{
    public class ComentController : Controller
    {
        // GET: Coment
        public ActionResult RegisterComent()
        {
            return View();
        }

        // Acción para procesar el formulario de registro
        [HttpPost]
        public ActionResult RegisterComent(ProductoViewModel modelo)
        {
            Phones PhoneViews = new Phones();
            if (PhoneViews.RegisterComent(modelo) == 0)
            {
                // Asigna el mensaje de éxito al ViewBag
                ViewBag.SuccessMessage = "El envío del comentario fue exitoso. El resto de la información será enviada por correo.";
            }
            else
            {
                TempData["ErrorMessage"] = "Hubo un error al procesar el comentario. Por favor, inténtalo de nuevo.";
            }

            return RedirectToAction("Index", "Home");
        }
    }
}