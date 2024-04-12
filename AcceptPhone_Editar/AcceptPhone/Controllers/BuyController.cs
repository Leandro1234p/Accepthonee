using System.Net.Mail;
using System.Net;
using AcceptPhone.Models;
using AcceptPhone.Repositories;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.Mvc;
using System;
using MimeKit;
using System.IO;
using System.Text;

namespace AcceptPhone.Controllers
{
    public class BuyController : Controller
    {
        // Acción para mostrar el formulario de registro
        public ActionResult RegisterBuy()
        {
            return View();
        }

        // Acción para procesar el formulario de registro
        [HttpPost]
        public ActionResult RegisterBuy(RegisterBuyViewModel modelo)
        {
            // Aquí guardar el usuario en la base de datos
            // y redirige a una página de inicio de sesión o confirmación.
            BuyRepository buyRepository = new BuyRepository();
            if (buyRepository.RegisterBuy(modelo) == 0)
            {

            }
            else
            {

            }
            string imagePath = Server.MapPath("~/Images/AcceptPhone_Logo.jpg");

            // Convierte la imagen a formato Base64
            string imageBase64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(imagePath));

            // Construir el mensaje HTML mejorado
            string mensaje = $@"<img src='data:image/jpg;base64,{imageBase64}' alt='AcceptPhone Logo'/>
                        <p>Señor(a) {modelo.Nombre},</p>
                        <p>Identificado con el número de cédula {modelo.Cedula} y el número de teléfono {modelo.Telefono}, usted está aceptando la compra de este dispositivo en nuestra empresa AcceptPhone.</p>
                        <p>Es un gusto tenerlo como cliente. No olvide que en nuestra página tenemos un buzón de sugerencias que puede usar o por medio de este correo se responderán sus dudas o sugerencias.</p>";

            // Envía el correo electrónico
            EnviarNotificacionCorreo(modelo.Email, "Compra realizada", mensaje);

            return RedirectToAction("Index", "Home"); // Redirige al usuario a la página de inicio de sesión
        }


        private void EnviarNotificacionCorreo(string destinatario, string asunto, string mensaje)
        {
            // Crear un correo electrónico
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("accepfphone@gmail.com");
            correo.To.Add(new MailAddress(destinatario));
            correo.Subject = asunto;
            string body = $@"<!DOCTYPE html>
                        <html>
                        <head>
                            <meta charset=""UTF-8"">
                            <style>
                                body {{
                                    font-family: Arial, sans-serif;
                                    background-color: #f4f4f4;
                                    padding: 20px;
                                    text-align: center;
                                }}
                                .container {{
                                    max-width: 600px;
                                    margin: 0 auto;
                                    background-color: #fff;
                                    padding: 20px;
                                    border-radius: 10px;
                                    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                                }}
                                img {{
                                    width: 100px;
                                    height: 100px;
                                }}
                                p {{
                                    margin-bottom: 15px;
                                }}
                            </style>
                        </head>
                        <body>
                            <div class='container'>
                                {mensaje}
                            </div>
                        </body>
                        </html>";


            correo.Body = body;
            correo.IsBodyHtml = true;

            // Configurar el servidor SMTP (en este caso, Gmail)
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("accepfphone@gmail.com", "tskdntxqbbebhrbm");
                smtp.EnableSsl = true;

                // Enviar el correo electrónico
                smtp.Send(correo);
            }
        }
        
    }

}

