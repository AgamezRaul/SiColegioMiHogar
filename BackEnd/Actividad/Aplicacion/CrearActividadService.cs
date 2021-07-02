using BackEnd.Base;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Actividad.Aplicacion
{
    public class CrearActividadService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearActividadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearActividadResponse EjecutarCrearActividad(CrearActividadRequest request)
        {
            IReadOnlyList<string> errors = request.CanCrear(request);
            if (errors.Any())
            {
                string ListaErrors = "Errores: " + string.Join(",", errors);
                return new CrearActividadResponse(ListaErrors);
            }
            var actividad = _unitOfWork.ActividadServiceRepository.FindFirstOrDefault(t => t.Descripcion == request.Descripcion);
            if (actividad != null)
            {
                return new CrearActividadResponse($"Ya existe la actividad");
            }
            Actividad newActividad = new Actividad(request.Descripcion, request.Porcentaje, request.IdMateria, request.IdPeriodo);
            _unitOfWork.ActividadServiceRepository.Add(newActividad);
            _unitOfWork.Commit();
            return new CrearActividadResponse($"Actividad creada exitosamente");
        }
    }
}
