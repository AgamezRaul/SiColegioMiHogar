using BackEnd.Base;
using BackEnd.Estudiante.Aplicacion.Request;
using BackEnd.Estudiante.Aplicacion.Services.Actualizar;
using BackEnd.PreMatricula.Aplicacion.Request;
using BackEnd.Responsable.Aplicacion.Request;
using BackEnd.Responsable.Aplicacion.Services.Actualizar;

namespace BackEnd.PreMatricula.Aplicacion.Service.Actualizar
{
    public class ActualizarPreMatriculaAllService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarEstudianteService estudianteService;
        public ActualizarEstudianteRequest estudianteRequest;
        public ActualizarResponsableService responsableService;
        public ActualizarResponsableRequest responsableRequest;

        public ActualizarPreMatriculaAllService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            estudianteService = new ActualizarEstudianteService(_unitOfWork);
            responsableService = new ActualizarResponsableService(_unitOfWork);
        }
        public ActualizarPreMatriculaAllResponse Ejecutar(ActualizarPreMatriculaAllRequest request)
        {
            Dominio.PreMatricula prematricula = _unitOfWork.PreMatriculaServiceRepository.FindFirstOrDefault(t => t.IdUsuario == request.IdUsuario);
            if (prematricula == null)
            {
                return new ActualizarPreMatriculaAllResponse() { Message = $"PreMatricula no existe" };
            }
            else
            {
                var respuestaE = estudianteService.Ejecutar(request.Estudiante);
                foreach (var responsable in request.Responsables)
                {
                    var respuesta = responsableService.Ejecutar(responsable);
                }
                prematricula.FecPrematricula = request.FecPrematricula;
                _unitOfWork.PreMatriculaServiceRepository.Edit(prematricula);
                _unitOfWork.Commit();
                return new ActualizarPreMatriculaAllResponse() { Message = $"PreMatricula Actualizada Exitosamente" };

            }
        }
    }
}
