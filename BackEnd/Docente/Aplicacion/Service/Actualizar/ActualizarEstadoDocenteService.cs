using BackEnd.Base;
using BackEnd.Docente.Aplicacion.Request;

namespace BackEnd.Docente.Aplicacion.Service.Actualizar
{
    public class ActualizarEstadoDocenteService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarEstadoDocenteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarEstadoDocenteResponse EjecutarActualizarEstado(ActualizarEstadoDocenteRequest request)
        {
            Dominio.Docente docente = _unitOfWork.DocenteServiceRepository.FindFirstOrDefault(t => t.Id == request.IdDocente);
            if (docente == null)
            {
                return new ActualizarEstadoDocenteResponse($"Docente no existe");
            }
            docente.Estado = request.Estado;
            _unitOfWork.DocenteServiceRepository.Edit(docente);
            return new ActualizarEstadoDocenteResponse($"Estado del Docente actualizado exitosamente");
        }
    }
}
