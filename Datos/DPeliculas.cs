using Datos.BaseDatos.Modelos;
using Datos.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DPeliculas
    {
        UnitOfWork _unitOfWork;

        public DPeliculas()
        {
            _unitOfWork = new UnitOfWork();
        }
        public int PeliculaId { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Autores { get; set; }
        public int Existencia { get; set; }
        public decimal PrecioRenta { get; set; }
        public bool Estado { get; set; }

        public List<Peliculas> RegistrosTodos()
        {
            return _unitOfWork.Repository<Peliculas>().Consulta().ToList();
        }

        public int Guardar(Peliculas guardar)
        {
            if (guardar.PeliculaId == 0)
            {
                _unitOfWork.Repository<Peliculas>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<Peliculas>().Consulta().FirstOrDefault(c => c.PeliculaId ==  guardar.PeliculaId);
                
                if (ActualizarInDB != null)
                {
                    ActualizarInDB.Nombre = guardar.Nombre;
                    ActualizarInDB.Genero = guardar.Genero;
                    ActualizarInDB.Autores = guardar.Autores;
                    ActualizarInDB.Existencia = guardar.Existencia;
                    ActualizarInDB.PrecioRenta = guardar.PrecioRenta;
                    ActualizarInDB.Estado = guardar.Estado;

                    _unitOfWork.Repository<Peliculas>().Editar(guardar);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int Eliminar(int EliminarPorID)
        {
            var RegistroInDb = _unitOfWork.Repository<Peliculas>().Consulta().FirstOrDefault(c => c.PeliculaId == EliminarPorID);
            if (RegistroInDb != null)
            {
                _unitOfWork.Repository<Peliculas>().Eliminar(RegistroInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
