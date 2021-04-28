using BackEnd.Base;
using BackEnd.Matricula.Aplicacion.Request;
using BackEnd.PreMatricula.Aplicacion.Request;
using BackEnd.PreMatricula.Aplicacion.Service.Actualizar;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Matricula.Aplicacion.Service.Crear
{
    public class CrearMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ActualizarPreMatriculaService preMatriculaService;

        public CrearMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            preMatriculaService = new ActualizarPreMatriculaService(_unitOfWork);
        }
        public CrearMatriculaResponse EjecutarCrearMatricula(CrearMatriculaRequest request)
        {
            var matricula = _unitOfWork.MatriculaServiceRepository.FindFirstOrDefault(t => t.IdePreMatricula == request.IdPreMatricula);
            if (matricula != null)
            {
                return new CrearMatriculaResponse($"Matricula ya existe");
            }
            IReadOnlyList<string> errors = request.CanCrear(request);
            if (errors.Any())
            {
                string listaErrors = "Errores: " + string.Join(".", errors);
                return new CrearMatriculaResponse(listaErrors);
            }
            Dominio.Matricula newMatricula = new Dominio.Matricula(request.FecConfirmacion, request.IdPreMatricula);
            ActualizarPreMatriculaRequest preMatriculaRequest = new ActualizarPreMatriculaRequest
            {
                id = request.IdPreMatricula,
                Estado = "Confirmado"
            };
            var respuestaPrematricula = preMatriculaService.EjecutarActualizarPrematricula(preMatriculaRequest);
            if (respuestaPrematricula.isOk())
            {
                _unitOfWork.MatriculaServiceRepository.Add(newMatricula);
                _unitOfWork.Commit();
                return new CrearMatriculaResponse($"Matricula Creada Exitosamente");
            }
            return new CrearMatriculaResponse($"No se logró crear la matricula");
        }
    }
}
