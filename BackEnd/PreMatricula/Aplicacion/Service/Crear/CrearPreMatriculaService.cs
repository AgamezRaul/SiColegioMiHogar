using BackEnd.Base;
using BackEnd.Estudiante.Aplicacion.Request;
using BackEnd.Estudiante.Aplicacion.Services.Crear;
using BackEnd.PreMatricula.Aplicacion.Request;
using BackEnd.Responsable.Aplicacion.Request;
using BackEnd.Responsable.Aplicacion.Services.Crear;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.PreMatricula.Aplicacion.Service.Crear
{
    public class CrearPreMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly CrearEstudianteService _crearEstudianteService;
        private readonly CrearResponsableService responsableService;

        public CrearPreMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _crearEstudianteService = new CrearEstudianteService(_unitOfWork);
            responsableService = new CrearResponsableService(_unitOfWork);
        }
        public CrearPreMatriculaResponse EjecutarCrearPreMatricula(CrearPreMatriculaRequest request)
        {
            var prematricula = _unitOfWork.PreMatriculaServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (prematricula != null)
            {
                return new CrearPreMatriculaResponse($"PreMatricula ya existe");
            }

            IReadOnlyList<string> errors = request.CanCrear(request);
            if (errors.Any())
            {
                string listaErrors = "Errores:" + string.Join(",", errors);
                return new CrearPreMatriculaResponse(listaErrors);
            }
            Dominio.PreMatricula newPreMatricula = new Dominio.PreMatricula(request.FecPrematricula, request.IdUsuario, request.Estado);
            var respuestaE = _crearEstudianteService.Ejecutar(request.Estudiante);
            var respuesta = responsableService.Ejecutar(request.Responsables);
            if (respuesta.isOk() && respuestaE.isOk())
            {
                _unitOfWork.PreMatriculaServiceRepository.Add(newPreMatricula);
                _unitOfWork.Commit();
                return new CrearPreMatriculaResponse($"PreMatricula Creada Exitosamente");
            }
            return new CrearPreMatriculaResponse($"No se creó la prematricula");
        }
    }
}
