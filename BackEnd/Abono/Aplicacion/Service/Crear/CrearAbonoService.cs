using System.Collections.Generic;
using System.Linq;
using BackEnd.Abono.Aplicacion.Request;
using BackEnd.Base;
using BackEnd.Mensualidad.Aplicacion.Request;
using BackEnd.Mensualidad.Aplicacion.Service.Actualizar;

namespace BackEnd.Abono.Aplicacion.Service.Crear
{
    public class CrearAbonoService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ActualizarMensualidadRequest actualizarMensualidadRequest;
        readonly ActualizarMensualidadService actualizarMensialidadService;
        public CrearAbonoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            actualizarMensualidadRequest= new ActualizarMensualidadRequest();
            actualizarMensialidadService = new ActualizarMensualidadService(_unitOfWork);
        }
        public CrearAbonoResponse Ejecutar(CrearAbonoRequest request)
        {
            var abono = _unitOfWork.AbonoServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            var mensualidad = _unitOfWork.MensualidadServiceRepository.FindFirstOrDefault(t => t.Id == request.IdMensualidad);
            if (abono != null)
            {
                return new CrearAbonoResponse($"Abono ya existe");
            }
            if (mensualidad == null)
            {
                return new CrearAbonoResponse($"Mensualidad No existe");
            }

            IReadOnlyList<string> errors = request.CanCrear(request);
            if (errors.Any())
            {
                string ListaErrors = "Errores: " + string.Join(",", errors);
                return new CrearAbonoResponse(ListaErrors);
            }
            actualizarMensualidadRequest.Deuda = mensualidad.Deuda - request.ValorAbono;
            actualizarMensualidadRequest.id = mensualidad.Id;
            var respuesta = actualizarMensialidadService.Ejecutar(actualizarMensualidadRequest);
            if (respuesta.isOk()) {
                Dominio.Abono newAbono = new Dominio.Abono(request.Mes, request.FechaPago, request.ValorAbono, request.EstadoAbono, request.IdMensualidad);
                _unitOfWork.AbonoServiceRepository.Add(newAbono);
                _unitOfWork.Commit();
                return new CrearAbonoResponse($"Abono Creado Exitosamente");
            }
            return new CrearAbonoResponse($"Error al Crear Abono");

        }
    }
}
