using BackEnd.Base;

namespace BackEnd.Actividad.Aplicacion
{
    public class EliminarActividadService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarActividadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarActividadResponse EjecutarEliminar(int id)
        {
            Actividad actividad = _unitOfWork.ActividadServiceRepository.FindFirstOrDefault(t => t.Id == id);
            if (actividad == null)
            {
                return new EliminarActividadResponse($"Actividad no existe");
            }
            _unitOfWork.ActividadServiceRepository.Delete(actividad);
            _unitOfWork.Commit();
            return new EliminarActividadResponse($"Actividad eliminada exitosamente");
        }
    }
}
