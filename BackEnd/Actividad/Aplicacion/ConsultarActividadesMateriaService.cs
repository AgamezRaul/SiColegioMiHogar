using BackEnd.Base;
using BackEnd.Periodo.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Actividad.Aplicacion
{
    public class ConsultarActividadesMateriaService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarActividadesMateriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public List<Actividad> GetActividades(int idMateria)
        {
            var actividades = _unitOfWork.ActividadServiceRepository.FindBy(x => x.IdMateria == idMateria).ToList();
            return actividades;
        }
    }
}
