using BackEnd.Base;
using BackEnd.PreMatricula.Aplicacion.Request;

namespace BackEnd.PreMatricula.Aplicacion.Service.Actualizar
{
    public class ActualizarPreMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarPreMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarPreMatriculaResponse EjecutarActualizarPrematricula(ActualizarPreMatriculaRequest request)
        {
            Dominio.PreMatricula prematricula = _unitOfWork.PreMatriculaServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (prematricula == null)
            {
                return new ActualizarPreMatriculaResponse($"PreMatricula no existe");
            }
            prematricula.Estado = request.Estado;
            _unitOfWork.PreMatriculaServiceRepository.Edit(prematricula);
            return new ActualizarPreMatriculaResponse($"PreMatricula Actualizada Exitosamente");
        }
    }
}
