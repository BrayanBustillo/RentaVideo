using Datos;
using Datos.BaseDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NPeliculas
    {
        private DPeliculas dvariable;

        public NPeliculas()
        {
            dvariable = new DPeliculas();
        }

        public List<Peliculas> obtener()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(Peliculas agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(Peliculas aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }
    }
}
