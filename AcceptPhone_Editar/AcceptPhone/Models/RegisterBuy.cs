    
using System.ComponentModel.DataAnnotations;

namespace AcceptPhone.Models
{
    // La clase RegisterBuyViewModel se utiliza para representar los datos del formulario de registro de compra.
    public class RegisterBuyViewModel
    {

        [Key]
        public int VentaId { get; set; }

        [Required]
        [Display(Name = "Nombre de usuario")]
        public string Nombre { get; set; }  // Propiedad para el nombre del usuario

        [Required]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }  // Propiedad para el número de teléfono

        [Required]
        [Display(Name = "No. Cedula")]
        public string Cedula { get; set; }  // Propiedad para el número de cédula

        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }  // Propiedad para la dirección de correo electrónico

        [Required]
        [Display(Name = "Tipo de pago")]
        public string Tipopago { get; set; }  // Propiedad para el tipo de pago

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "No.Tarjeta")]
        public string Tarjeta { get; set; }  // Propiedad para el número de tarjeta

        // Aquí podrías agregar otras propiedades relacionadas con el registro de compras, si es necesario.

    }
}
