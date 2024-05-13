using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntrega
{
    public abstract class ProductoVendido
    {
        protected int Id { get; set; }
        protected int IdProducto { get; set; }
        protected int Stock { get; set; }
        protected int IdVenta { get; set; }


        public ProductoVendido (int id, int idProd, int stock, int idVenta) 
        {
            this.Id = id;
            this.IdProducto = idProd;
            this.Stock = stock;
            this.IdVenta = idVenta;
        }
    }
}
