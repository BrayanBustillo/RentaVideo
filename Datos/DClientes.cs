using Datos.BaseDatos.Modelos;
using Datos.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DClientes
    {
        UnitOfWork _unitOfWork;

        public DClientes()
        {
            _unitOfWork = new UnitOfWork();
        }
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Aepllidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public List<Clientes> RegistrosTodos()
        {
            return _unitOfWork.Repository<Clientes>().Consulta().ToList();
        }

        public int Guardar(Clientes guardar)
        {
            if (guardar.ClienteId == 0)
            {
                _unitOfWork.Repository<Clientes>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<Clientes>().Consulta().FirstOrDefault(c => c.ClienteId == guardar.ClienteId);

                if (ActualizarInDB != null)
                {
                    ActualizarInDB.Nombres = guardar.Nombres;
                    ActualizarInDB.Aepllidos = guardar.Aepllidos;
                    ActualizarInDB.FechaIngreso = guardar.FechaIngreso;
                    ActualizarInDB.Estado = guardar.Estado;

                    _unitOfWork.Repository<Clientes>().Editar(guardar);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int Eliminar(int EliminarPorID)
        {
            var RegistroInDb = _unitOfWork.Repository<Clientes>().Consulta().FirstOrDefault(c => c.ClienteId == EliminarPorID);
            if (RegistroInDb != null)
            {
                _unitOfWork.Repository<Clientes>().Eliminar(RegistroInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
