using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Modelos
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(75)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(75)]
        public string Aepllidos { get; set; }

        public DateTime FechaIngreso { get; set; }

        public bool Estado { get; set; }
    }
}
