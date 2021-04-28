using BackEnd.Base;
using BackEnd.Matricula.Aplicacion.Request;
using BackEnd.PreMatricula.Aplicacion.Request;
using BackEnd.PreMatricula.Aplicacion.Service.Actualizar;

namespace BackEnd.Matricula.Aplicacion.Service.Eliminar
{
    public class EliminarMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ActualizarPreMatriculaService _actualizarPrematriculaService;

        public EliminarMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _actualizarPrematriculaService = new ActualizarPreMatriculaService(_unitOfWork);
        }
        public EliminarMatriculaResponse EjecutarEliminarMatricula(EliminarMatriculaRequest request)
        {
            Mensualidad.Dominio.Mensualidad mensualidad = _unitOfWork.MensualidadServiceRepository.FindFirstOrDefault(t => t.IdMatricula == request.Id);
            if (mensualidad != null)
            {
                return new EliminarMatriculaResponse($"Primero elimine las mensualidades");
            }
            Dominio.Matricula matricula = _unitOfWork.MatriculaServiceRepository.FindFirstOrDefault(t => t.Id == request.Id);
            if (matricula == null)
            {
                return new EliminarMatriculaResponse($"Matricula no existe");
            }
            ActualizarPreMatriculaRequest preMatriculaRequest = new ActualizarPreMatriculaRequest
            {
                id = matricula.IdePreMatricula,
                Estado = "No Confirmado"
            };
            var respuestaPrematricula = _actualizarPrematriculaService.EjecutarActualizarPrematricula(preMatriculaRequest);
            if (respuestaPrematricula.isOk())
            {
                _unitOfWork.MatriculaServiceRepository.Delete(matricula);
                _unitOfWork.Commit();
                return new EliminarMatriculaResponse($"Matricula Eliminado Exitosamente");
            }
            return new EliminarMatriculaResponse($"No se pudo eliminar la matricula");
        }
    }
}
