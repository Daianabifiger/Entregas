using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntrega.Models
{
    public class ProductoVendido
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int Stock { get; set; }
        public int IdVenta { get; set; }

        public ProductoVendido() 
        {

        }

        public ProductoVendido(int id, int idProd, int stock, int idVenta)
        {
            Id = id;
            IdProducto = idProd;
            Stock = stock;
            IdVenta = idVenta;
        }
    }
}
