using BackEnd.Base;
using BackEnd.Estudiante.Aplicacion.Request;

namespace BackEnd.Estudiante.Aplicacion.Services.Eliminar
{
    public class EliminarEstudianteService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarEstudianteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarEstudianteResponse Ejecutar(EliminarEstudianteRequest request)
        {
            Dominio.Estudiante estudiante = _unitOfWork.EstudianteServiceRepository.FindFirstOrDefault(t => t.IdUsuario == request.IdUsuario);
            if (estudiante == null)
            {
                return new EliminarEstudianteResponse($"Estudiante no existe");
            }
            _unitOfWork.EstudianteServiceRepository.Delete(estudiante);
            return new EliminarEstudianteResponse($"Estudiante Eliminado Exitosamente");
        }
    }
}
