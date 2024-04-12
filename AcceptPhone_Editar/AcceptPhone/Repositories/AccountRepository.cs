using AcceptPhone.Models;
using System;
using System.Configuration; // Añade la referencia al espacio de nombres System.Configuration para acceder a la cadena de conexión.
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace AcceptPhone.Repositories
{
    public class AccountRepository
    {
        // Verifica si un correo electrónico ya está en uso.
        public bool IsEmailInUse(string email)
        {
            // Obtiene la cadena de conexión desde el archivo de configuración.
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                // Lanza una excepción si la cadena de conexión no está configurada.
                throw new ArgumentNullException("connectionString", "La cadena de conexión no está configurada.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        // Registra un nuevo usuario.
        public int Register(RegisterViewModel model)
        {
            int result = 0;
            // Obtiene la cadena de conexión desde el archivo de configuración.
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                // Lanza una excepción si la cadena de conexión no está configurada.
                throw new ArgumentNullException("connectionString", "La cadena de conexión no está configurada.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Usuarios (NombreUsuario, Email, Password) VALUES (@NombreUsuario, @Email, @Password)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", model.Username);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    byte[] Password = Encoding.UTF8.GetBytes(model.Password);
                    command.Parameters.Add("@Password", SqlDbType.VarBinary).Value = Password;
                    result = command.ExecuteNonQuery();
                }

                connection.Close();
            }

            return result;
        }
        public bool login( string email, string password)
        {
            bool isValid = false;

            // Obtiene la cadena de conexión desde el archivo de configuración.
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                // Lanza una excepción si la cadena de conexión no está configurada.
                throw new ArgumentNullException("connectionString", "La cadena de conexión no está configurada.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Consulta para verificar si los datos existen en la base de datos.
                string query = "SELECT COUNT(*) FROM Usuarios WHERE  Email = @Email AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@Email", email);
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    command.Parameters.Add("@Password", SqlDbType.VarBinary).Value = passwordBytes;

                    int count = (int)command.ExecuteScalar();

                    isValid = count > 0;
                }
            }

            return isValid;
        }
    }
}
