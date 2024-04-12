using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AcceptPhone
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Account",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Home", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Buy",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Buy", action = "RegisterBuy", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PhonesProducto",
                 url: "Phones/Producto",
                defaults: new { controller = "Home", action = "PhoneViews" }
             );
            routes.MapRoute(
            name: "ImageUpload",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "PhoneViews", id = UrlParameter.Optional }
              );
            routes.MapRoute(
           name: "Coment",
           url: "{controller}/{action}/{id}",
           defaults: new { controller = "Home", action = "PhonesViews" }
           );
            routes.MapRoute(
            name: "Login",
            url: "Account/Login",
            defaults: new { controller = "Account", action = "Login" }
            );
            routes.MapRoute(
            name: "Logout",
            url: "Account/Logout",
            defaults: new { controller = "Account", action = "Logout" }
            );
            routes.MapRoute(
           name: "Admin",
           url: "Admin/{action}/{id}",
           defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
       );
            


        }
    }
}
