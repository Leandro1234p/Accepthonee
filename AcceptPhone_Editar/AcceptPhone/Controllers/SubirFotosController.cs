using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;

namespace TuProyecto.Controllers
{
    public class SubirFotosController : Controller
    {
        private const string BucketName = "tu-bucket-s3"; // Reemplaza con tu nombre de bucket

        private readonly IAmazonS3 _s3Client;

        public SubirFotosController()
        {
            // Configura el cliente de S3 (asegúrate de configurar las credenciales)
            _s3Client = new AmazonS3Client("ACCESS_KEY", "SECRET_KEY", Amazon.RegionEndpoint.USWest2);
        }

        [Authorize(Roles = "Usuario, Administrador")]
        public ActionResult Index()
        {
            // Obtén la lista de URLs de fotos en S3
            var fotosUrls = ObtenerFotosUrlsDesdeS3();
            return View(fotosUrls);
        }

        [Authorize(Roles = "Usuario, Administrador")]
        public ActionResult SubirFoto()
        {
            return View();
        }

        [Authorize(Roles = "Usuario, Administrador")]
        [HttpPost]
        public ActionResult GuardarFoto(HttpPostedFileBase foto)
        {
            if (foto != null && foto.ContentLength > 0)
            {
                var nombreImagen = $"{Guid.NewGuid()}{Path.GetExtension(foto.FileName)}";
                var rutaS3 = $"https://{BucketName}.s3.amazonaws.com/{nombreImagen}";

                SubirFotoAS3(foto, nombreImagen);
                ViewBag.Mensaje = "Foto subida exitosamente.";
            }
            else
            {
                ViewBag.Mensaje = "Error al subir la foto.";
            }

            return View("SubirFoto");
        }

        private void SubirFotoAS3(HttpPostedFileBase foto, string nombreImagen)
        {
            using (var transferUtility = new TransferUtility(_s3Client))
            {
                transferUtility.Upload(new TransferUtilityUploadRequest
                {
                    InputStream = foto.InputStream,
                    Key = nombreImagen,
                    BucketName = BucketName,
                    CannedACL = S3CannedACL.PublicRead // Haz la imagen pública
                });
            }
        }

        private IEnumerable<string> ObtenerFotosUrlsDesdeS3()
        {
            var fotosUrls = new List<string>();
            var request = new ListObjectsV2Request
            {
                BucketName = BucketName
            };

            var response = _s3Client.ListObjectsV2(request);

            foreach (var objeto in response.S3Objects)
            {
                fotosUrls.Add($"https://{BucketName}.s3.amazonaws.com/{objeto.Key}");
            }

            return fotosUrls;
        }
    }
}