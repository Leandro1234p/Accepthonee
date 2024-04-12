using System.Web.Mvc;
using System.Web.Security;

namespace AcceptPhone.Controllers
{
    public class HomeController : Controller
    {
        // es la ruta raíz y devuelve la vista "Index".
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //  responde a la ruta "/Home/Contact" y devuelve la vista "Contact".
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //  responde a una ruta  y devuelve la vista "Account".
        public ActionResult Account()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //  responde a una ruta  y devuelve la vista "Buy".
        public ActionResult Buy()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //  responde a una ruta  y devuelve la vista "PhonesViews".
        public ActionResult PhonesViews()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
       
    }
}
