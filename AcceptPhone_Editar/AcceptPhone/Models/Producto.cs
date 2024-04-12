
using System.ComponentModel.DataAnnotations;


namespace AcceptPhone.Models
{
    // La clase ProductoViewModel se utiliza para representar los datos relacionados con un producto y comentarios.
    public class ProductoViewModel
    {
        [Display(Name = "Nombre de usuario")]
        public string Nombre { get; set; }  // Propiedad para el nombre de usuario

        [Display(Name = "Correo electrónico")]
        public string Correo { get; set; }  // Propiedad para la dirección de correo electrónico

        [Display(Name = "Comentario")]
        public string Comentario { get; set; }  // Propiedad para el comentario del usuario

        // Aquí podrías agregar otras propiedades relacionadas con los productos y comentarios, si es necesario.

    }
}
