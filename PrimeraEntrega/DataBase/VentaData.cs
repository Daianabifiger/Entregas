using PrimeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntrega.DataBase
{
    internal class VentaData
    {
        public static bool EliminarVenta(int IdVenta)
        {
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Venta WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();

                command.Parameters.AddWithValue("id", IdVenta);

                return command.ExecuteNonQuery() > 0;
            }

        }


        public static bool CrearVenta(Venta venta)
        {
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Venta (id, comentario, idUsuario) VALUES (@id,@comentario,@idUsuario)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", venta.Id);
                command.Parameters.AddWithValue("comentario", venta.Comentario);
                command.Parameters.AddWithValue("idUsuario", venta.IdUsuario);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static Usuario ObtenerVenta(int id)
        {
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Venta WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int Id = Convert.ToInt32(reader[0]);
                    string comentario = reader.GetString(1);
                    int userId = Convert.ToInt32(reader[2]);

                    Venta venta = new Venta(Id, comentario, userId);
                    return venta;
                }

                throw new Exception("Id no encontrado");
            }
        }

        public static bool ModificarVenta(int Id, Venta venta)
        {
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Venta SET id = @id, comentario = @comentario, idUsuario = @idUsuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("id", Id);
                command.Parameters.AddWithValue("comentario", venta.Comentario);
                command.Parameters.AddWithValue("idUsuario", venta.IdUsuario);

                conn.Open();

                command.ExecuteNonQuery();

                conn.Close();

                return true;
            }
        }

        public static List<Venta> ListarVenta()
        {
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";

            List<Venta> ListaVenta = new List<Venta>();
            string query = "SELECT * FROM Venta";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Venta venta = new Venta();
                            venta.Id = Convert.ToInt32(dataReader["Id"]);
                            venta.Comentario = dataReader["comentario"].ToString();
                            venta.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);

                            ListaVenta.Add(venta);
                        }
                    }
                }

            }
            return ListaVenta;
        }
    }
}
