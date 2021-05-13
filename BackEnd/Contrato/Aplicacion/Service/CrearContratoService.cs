using BackEnd.Base;
using BackEnd.Contrato.Aplicacion.Request;
using BackEnd.Docente.Aplicacion.Request;
using BackEnd.Docente.Aplicacion.Service.Actualizar;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Contrato.Aplicacion.Service
{
    public class CrearContratoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ActualizarEstadoDocenteService _actualizarEstadoDocenteService;

        public CrearContratoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _actualizarEstadoDocenteService = new ActualizarEstadoDocenteService(_unitOfWork);
        }
        public CrearContratoResponse EjecutarCrearContrato(CrearContratoRequest request)
        {
            var contrato = _unitOfWork.ContratoServiceRepository.FindFirstOrDefault(t => t.IdDocente == request.IdDocente);

            if (contrato != null)
            {
                return new CrearContratoResponse($"El docente ya tiene un contrato");
            }
            IReadOnlyList<string> errors = request.CanCrear(request);
            if (errors.Any())
            {
                string ListaErrors = "Errores: " + string.Join(",", errors);
                return new CrearContratoResponse(ListaErrors);
            }
            ActualizarEstadoDocenteRequest actualizarEstadoDocenteRequest = new ActualizarEstadoDocenteRequest();
            actualizarEstadoDocenteRequest.IdDocente = request.IdDocente;
            Dominio.Contrato newContrato = new Dominio.Contrato(request.FechaInicio, request.FechaFin, request.Sueldo, request.IdDocente);
            var respuestaEstado = _actualizarEstadoDocenteService.EjecutarActualizarEstado(actualizarEstadoDocenteRequest);
            if (respuestaEstado.isOk())
            {
                _unitOfWork.ContratoServiceRepository.Add(newContrato);
                _unitOfWork.Commit();
                return new CrearContratoResponse($"Contrato Creado Exitosamente");
            }
            return new CrearContratoResponse($"Error al crear contrato");
        }
    }
}
