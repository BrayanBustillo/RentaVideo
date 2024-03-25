using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NClientes
    {
        private DClientes dvariable;

        public NClientes()
        {
            dvariable = new DClientes();
        }

        public List<Clientes> obtener()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(Clientes agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(Clientes aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }
    }
}
