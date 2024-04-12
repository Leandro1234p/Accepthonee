using AcceptPhone.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace AcceptPhone.Repositories
{
    public class Phones
    {
        // Este método se utiliza para registrar un comentario en la base de datos.
        public int RegisterComent(ProductoViewModel modelo)
        {
            int result = 0;

            // Obtenemos la cadena de conexión desde el archivo de configuración.
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

            // Establecemos una conexión a la base de datos.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL para insertar un nuevo comentario en la tabla "Comentarios".
                string query1 = "INSERT INTO Comentarios (Nombre, Correo, Comentario) VALUES (@Nombre, @Correo, @Comentario)";

                // Creamos un comando SQL y establecemos los parámetros.
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                    command.Parameters.AddWithValue("@Correo", modelo.Correo);
                    command.Parameters.AddWithValue("@Comentario", modelo.Comentario);

                    // Ejecutar la consulta de inserción.
                    result = command.ExecuteNonQuery();
                }

                // Cerramos la conexión a la base de datos.
                connection.Close();
            }

            // Devolvemos el resultado, que indica el éxito o el fallo de la operación de registro de comentario.
            return result;
        }
    }
}
