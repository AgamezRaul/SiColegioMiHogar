using BackEnd.Base;
using BackEnd.Matricula.Aplicacion.Request;

namespace BackEnd.Matricula.Aplicacion.Service.Actualizar
{
    public class ActualizarMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarMatriculaResponse Ejecutar(ActualizarMatriculaRequest request)
        {
            Dominio.Matricula matricula = _unitOfWork.MatriculaServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (matricula == null)
            {
                return new ActualizarMatriculaResponse($"Matricula no existe");
            }
            matricula.IdePreMatricula = request.IdPreMatricula;
            matricula.ValorMatricula = request.ValorMatricula;
            _unitOfWork.MatriculaServiceRepository.Edit(matricula);
            _unitOfWork.Commit();
            return new ActualizarMatriculaResponse($"Matricula Actualizada Exitosamente");
        }
    }
}
