using PrimeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntrega.DataBase
{
    internal class ProductoData
    {
        public static Producto ObtenerProducto(int id)
        {
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Producto WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int Id = Convert.ToInt32(reader[0]);
                    string Descripcion = reader.GetString(1);
                    double Costo = (double)Convert.ToDecimal(reader[2]);
                    double precioVenta = (double)Convert.ToDecimal(reader[3]);
                    int stock = Convert.ToInt32(reader[4]);
                    int idUsuario = Convert.ToInt32(reader[5]);

                    Producto producto = new Producto(Id, Descripcion, Costo, precioVenta, stock, idUsuario);
                    return producto;
                }

                    throw new Exception("Id no encontrado"); 
            }
        }

        public static List<Producto> ListarProducto()
        {
            List<Producto> listaProducto = new List<Producto>();
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Producto";
                connection.Open();

                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto();
                            producto.Id = Convert.ToInt32(reader["Id"]);
                            producto.Descripcion = reader["Descripciones"].ToString();
                            producto.Costo = (double)Convert.ToDecimal(reader["Costo"]);
                            producto.PrecioVenta = (double)Convert.ToDecimal(reader["PrecioVenta"]);
                            producto.Stock = Convert.ToInt32(reader["Stock"]);
                            producto.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                                
                            listaProducto.Add(producto);
                        }
                          

                    }
                }

            }

            return listaProducto;
        }


        public static bool CrearProducto(Producto producto)
        {
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Producto (id, descripcion, costo, precioVenta, stock, idUsuario) VALUES (@id, @descripcion, @costo, @precioVenta, @stock, @idUsusario)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", producto.Id);
                command.Parameters.AddWithValue("descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("costo", producto.Costo);
                command.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("idUsuario", producto.IdUsuario);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool EliminarProducto(int IdProducto)
        {
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Producto WHERE Id = @id"; 
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();

                command.Parameters.AddWithValue("id", IdProducto);

                return command.ExecuteNonQuery() > 0;
            }

        }

        public static bool ModificarProducto(int IdProducto, Producto producto)
        {
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Producto SET id = @id, descripcion = @descripcion, costo= @costo, precioVenta = @precioVenta, idUsuario = @idUsuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("id", producto.Id);
                command.Parameters.AddWithValue("descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("costo", producto.Costo);
                command.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("idUsuario", producto.IdUsuario);

                conn.Open();

                command.ExecuteNonQuery();

                conn.Close();

                return true;
            }
        }



    }
}
