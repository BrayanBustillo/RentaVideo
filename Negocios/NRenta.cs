using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NRenta
    {
        private DRentas dvariable;
        private DPeliculas dpelicula;

        public NRenta()
        {
            dvariable = new DRentas();
        }

        public List<Renta> obtener()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(Renta agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(Renta aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }

        public List<Renta> Existencia()
        {
            return dvariable.RegistrosTodos().Where(c => c.pelicula.Existencia > 0).ToList();
        }
    }
}
