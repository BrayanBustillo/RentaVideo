using Datos.BaseDatos.Modelos;
using Datos.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public  class DRentas
    {
        UnitOfWork _unitOfWork;

        public DRentas()
        {
            _unitOfWork = new UnitOfWork();
        }
        public int RentaId { get; set; }
        public int ClienteId { get; set; }
        public int PeliculaId { get; set; }
        public DateTime FechaRenta { get; set; }
        public DateTime FechaRetorno { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioRenta { get; set; }

        public List<Renta> RegistrosTodos()
        {
            return _unitOfWork.Repository<Renta>().Consulta().Include(c => c.cliente)
                                                             .Include(c => c.pelicula)
                                                             .ToList();
        }

        public int Guardar(Renta guardar)
        {
            if (guardar.RentaId == 0)
            {
                _unitOfWork.Repository<Renta>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<Renta>().Consulta().FirstOrDefault(c => c.RentaId == guardar.RentaId);

                if (ActualizarInDB != null)
                {
                    ActualizarInDB.ClienteId = guardar.ClienteId;
                    ActualizarInDB.PeliculaId = guardar.PeliculaId;
                    ActualizarInDB.Cantidad = guardar.Cantidad;
                    ActualizarInDB.PrecioRenta = guardar.PrecioRenta;

                    _unitOfWork.Repository<Renta>().Editar(ActualizarInDB);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int Eliminar(int EliminarPorID)
        {
            var RegistroInDb = _unitOfWork.Repository<Renta>().Consulta().FirstOrDefault(c => c.PeliculaId == EliminarPorID);
            if (RegistroInDb != null)
            {
                _unitOfWork.Repository<Renta>().Eliminar(RegistroInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
