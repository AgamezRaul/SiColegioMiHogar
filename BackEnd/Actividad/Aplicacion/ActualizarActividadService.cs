using BackEnd.Base;

namespace BackEnd.Actividad
{
    public class ActualizarActividadService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarActividadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarActividadResponse EjecutarActualizarActividad(ActualizarActividadRequest request)
        {
            Actividad actividad = _unitOfWork.ActividadServiceRepository.FindFirstOrDefault(t => t.Id == request.Id);
            if (actividad == null)
            {
                return new ActualizarActividadResponse($"Actividad no existe");
            }
            actividad.Descripcion = request.Descripcion;
            actividad.Porcentaje = request.Porcentaje;
            _unitOfWork.ActividadServiceRepository.Edit(actividad);
            _unitOfWork.Commit();
            return new ActualizarActividadResponse($"Actividad actualizada correctamente");
        }
    }
}
