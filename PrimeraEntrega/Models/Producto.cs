using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntrega.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        public Producto()
        {

        }
        public Producto(int id, string descripcion, double costo, double precioVenta, int stock, int idUsuario)
        {
            Id = id; ;
            Descripcion = descripcion;
            Costo = costo;
            PrecioVenta = precioVenta;
            Stock = stock;
            IdUsuario = idUsuario;
        }
    }
}
