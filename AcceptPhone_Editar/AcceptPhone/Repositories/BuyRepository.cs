using AcceptPhone.Models;
using System;
using System.Configuration; // Añade la referencia al espacio de nombres System.Configuration para acceder a la cadena de conexión.
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;

namespace AcceptPhone.Repositories
{
    public class BuyRepository
    {
        // Registra una compra.
        public int RegisterBuy(RegisterBuyViewModel modelo)
        {
            int result = 0;
            // Obtiene la cadena de conexión desde el archivo de configuración.
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query1 = "INSERT INTO Ventas (Nombre, Telefono, Cedula, Correo, TipodePago, NumeroTarjeta) VALUES (@NombreUsuario, @Telefono, @Cedula, @Correo, @TipodePago, @NumeroTarjeta)";

                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", modelo.Nombre);
                    command.Parameters.AddWithValue("@Telefono", modelo.Telefono);
                    command.Parameters.AddWithValue("@Cedula", modelo.Cedula);
                    command.Parameters.AddWithValue("@Correo", modelo.Email);
                    command.Parameters.AddWithValue("@TipodePago", modelo.Tipopago);
                    byte[] Tarjeta = Encoding.UTF8.GetBytes(modelo.Tarjeta);
                    command.Parameters.Add("@NumeroTarjeta", SqlDbType.VarBinary).Value = Tarjeta;
                    result = command.ExecuteNonQuery();
                }

                connection.Close();
            }

            return result;
        }
    }
}
