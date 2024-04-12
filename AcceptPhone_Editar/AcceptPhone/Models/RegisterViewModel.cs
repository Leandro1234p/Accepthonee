
using AcceptPhone.Models;
using System;
using System.ComponentModel.DataAnnotations;



namespace AcceptPhone.Models
{
    // La clase RegisterViewModel se utiliza para representar los datos del formulario de registro de usuario.
    public class RegisterViewModel
    {
        

        [Required(ErrorMessage = "Por favor, ingrese su nombre.")]
        [RegularExpression(@"^[A-Za-z\s]*$", ErrorMessage = "El campo 'Nombre' solo debe contener letras y espacios.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese su correo.")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$", ErrorMessage = "El campo 'Email' debe tener una dirección de correo válida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese una contraseña.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Por favor, confirme su contraseña.")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        internal static bool CheckPassword(string password, object passwordHash, object passwordSalt)
        {
            throw new NotImplementedException();
        }
    }
}
