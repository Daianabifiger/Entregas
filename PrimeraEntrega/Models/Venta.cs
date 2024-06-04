using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntrega.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int IdUsuario { get; set; }

        public Venta() 
        {

        }
        public Venta (int id, string comentario, int idUsuario)
        {
            this.Id = id;
            this.Comentario = comentario;
            this.IdUsuario = idUsuario;
        }
    } 
}
