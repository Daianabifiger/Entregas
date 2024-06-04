using PrimeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntrega.DataBase
{
    internal class ProductoVendidoData
    {
        public static ProductoVendido ObtenerProducto(int id)
        {
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ProductoVendido WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int Id = Convert.ToInt32(reader[0]);
                    int idProducto = Convert.ToInt32(reader[1]);
                    int stock = Convert.ToInt32(reader[2]);
                    int idVenta = Convert.ToInt32(reader[3]);


                    ProductoVendido producto = new ProductoVendido(Id, idProducto, stock, idVenta);
                    return producto;
                }

                throw new Exception("Id no encontrado");
            }
        }

        public static List<ProductoVendido> ListarProductoVendido()
        {
            List<ProductoVendido> listaProductoVend = new List<ProductoVendido>();
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ProductoVendido";
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductoVendido producto = new ProductoVendido();
                            producto.Id = Convert.ToInt32(reader["Id"]);
                            producto.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                            producto.Stock = Convert.ToInt32(reader["Stock"]);
                            producto.IdVenta = Convert.ToInt32(reader["IdVenta"]);

                            listaProductoVend.Add(producto);
                        }


                    }
                }

            }

            return listaProductoVend;
        }


        public static bool CrearProductoVendido(ProductoVendido producto)
        {
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ProductoVendido (id, idProducto, stock, idVenta) VALUES (@id, @idProducto, @stock, @idVenta)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", producto.Id);
                command.Parameters.AddWithValue("idProducto", producto.IdProducto);
                command.Parameters.AddWithValue("stock", producto.Stock);
                command.Parameters.AddWithValue("idVenta", producto.IdVenta);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool EliminarProductoVendido(int Id)
        {
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ProductoVendido WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();

                command.Parameters.AddWithValue("id", Id);

                return command.ExecuteNonQuery() > 0;
            }

        }

        public static bool ModificarProductoVendido(int Id, ProductoVendido producto)
        {
            string connectionString = "Server=. ; Database=SistemaGestion ; Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE ProductoVendido SET id = @id, idProducto = @idProducto, idVenta = @idVenta, stock = @stock WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("id", producto.Id);
                command.Parameters.AddWithValue("idProducto", producto.IdProducto);
                command.Parameters.AddWithValue("stock", producto.Stock);
                command.Parameters.AddWithValue("idVenta", producto.IdVenta);

                conn.Open();

                command.ExecuteNonQuery();

                conn.Close();

                return true;
            }
        }
    }
}
