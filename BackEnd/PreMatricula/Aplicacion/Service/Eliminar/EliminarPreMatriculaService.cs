using BackEnd.Base;
using BackEnd.Estudiante.Aplicacion.Request;
using BackEnd.Estudiante.Aplicacion.Services.Eliminar;
using BackEnd.PreMatricula.Aplicacion.Request;
using BackEnd.Responsable.Aplicacion.Request;
using BackEnd.Responsable.Aplicacion.Services.Eliminar;

namespace BackEnd.PreMatricula.Aplicacion.Service.Eliminar
{
    public class EliminarPreMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly EliminarEstudianteService estudianteService;
        private readonly EliminarResponsableService responsableService;
        public EliminarPreMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            estudianteService = new EliminarEstudianteService(_unitOfWork);
            responsableService = new EliminarResponsableService(_unitOfWork);
        }
        public EliminarPreMatriculaResponse Ejecutar(EliminarPreMatriculaRequest request)
        {
            Dominio.PreMatricula prematricula = _unitOfWork.PreMatriculaServiceRepository.FindFirstOrDefault(t => t.IdUsuario == request.UsuarioId);
            if (prematricula == null)
            {
                return new EliminarPreMatriculaResponse($"PreMatricula no existe");
            }
            if (prematricula.Estado == "Confirmado")
            {
                return new EliminarPreMatriculaResponse($"Prematricula confirmada, primero elimine la matrícula");
            }
            EliminarEstudianteRequest estudianteRequest = new EliminarEstudianteRequest();
            estudianteRequest.IdUsuario = request.UsuarioId;
            EliminarResponsableRequest responsableRequest = new EliminarResponsableRequest();
            responsableRequest.UsuarioId = request.UsuarioId;
            var respuestaE = estudianteService.Ejecutar(estudianteRequest);
            var respuesta = responsableService.Ejecutar(responsableRequest);
            if (respuesta.isOk() && respuestaE.isOk())
            {
                _unitOfWork.PreMatriculaServiceRepository.Delete(prematricula);
                _unitOfWork.Commit();
                return new EliminarPreMatriculaResponse($"PreMatricula Eliminado Exitosamente");
            }
            return new EliminarPreMatriculaResponse($"PreMatricula no se Eliminó, ocurrió un error");
        }
    }
}
