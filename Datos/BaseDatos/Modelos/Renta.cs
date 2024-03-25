using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Modelos
{
    public class Renta
    {
        [Key]
        public int RentaId { get; set; }

        public int ClienteId { get; set; }

        public int PeliculaId { get; set; }

        public DateTime FechaRenta { get; set; }
        public DateTime FechaRetorno{ get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioRenta { get; set; }

        //-------------------------------------
        public Clientes cliente { get; set; }
        public Peliculas pelicula { get; set; }
    }
}
