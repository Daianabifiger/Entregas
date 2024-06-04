using PrimeraEntrega.DataBase;
using System.Data.SqlClient;

namespace PrimeraEntrega.Models
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductoData productoData = new ProductoData();
            ProductoVendidoData productoVendidoData = new ProductoVendidoData();
            UsuarioData usuarioData = new UsuarioData();
            VentaData ventaData = new VentaData();

            try
            {
                Producto producto = new Producto(1, "Buzo overside", 7000, 15000, 5, 2);
                if (ProductoData.CrearProducto(producto))
                {
                    Console.WriteLine("Producto creado");
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Usuario usuario = new Usuario(1, "Daiana", "Bifiger", "daiBifig", "dai123", "dbifiger@gmail.com");
                if (UsuarioData.CrearUsuario(usuario))
                {
                    Console.WriteLine("Creaste un nuevo usuario");
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Venta venta = new Venta(10, "compraste un buzo overside", 1);
                if (VentaData.CrearVenta(venta))
                {
                    Console.WriteLine("Realizaste una venta");
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                ProductoVendido productoVendido = new ProductoVendido(5, 1, 5, 10);
                if (ProductoVendidoData.CrearProductoVendido(productoVendido))
                {
                    Console.WriteLine("Creaste un producto vendido");

                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}