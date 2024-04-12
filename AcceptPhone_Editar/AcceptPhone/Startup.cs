using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcceptPhone
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configuración de OWIN (por ejemplo, configuración de autenticación)
            app.UseCookieAuthentication(
                 new CookieAuthenticationOptions
                 {
                     AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    ExpireTimeSpan = TimeSpan.FromMinutes(30),  
                    LoginPath =  new PathString("/Account/Login")
                 });


                     
                     



        }
    }
}



