using BackEnd.Abono.Aplicacion.Request;
using BackEnd.Base;
using BackEnd.Mensualidad.Aplicacion.Request;
using BackEnd.Mensualidad.Aplicacion.Service.Actualizar;

namespace BackEnd.Abono.Aplicacion.Service.Actualizar
{
    public class ActualizarAbonoService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ActualizarMensualidadRequest actualizarMensualidadRequest;
        readonly ActualizarMensualidadService actualizarMensialidadService;
        public ActualizarAbonoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            actualizarMensualidadRequest = new ActualizarMensualidadRequest();
            actualizarMensialidadService = new ActualizarMensualidadService(_unitOfWork);
        }
        public ActualizarAbonoResponse Ejecutar(ActualizarAbonoRequest request)
        {
            Dominio.Abono abono = _unitOfWork.AbonoServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            var mensualidad = _unitOfWork.MensualidadServiceRepository.FindFirstOrDefault(t => t.Id == request.idMesualidad);
            if (abono == null)
            {
                return new ActualizarAbonoResponse($"Abono no existe");
            }
            if (mensualidad == null)
            {
                return new ActualizarAbonoResponse($"Mensualidad No existe");
            }
            if(abono.EstadoAbono == "Anulado")
            {
                return new ActualizarAbonoResponse($"No se puede actulizar un abono anulado");
            }
            else
            {
                actualizarMensualidadRequest.Deuda = mensualidad.Deuda + abono.ValorAbono - request.ValorAbono;
                var respuesta = actualizarMensialidadService.Ejecutar(actualizarMensualidadRequest);
                if (respuesta.isOk())
                {
                    abono.ValorAbono = request.ValorAbono;
                    _unitOfWork.AbonoServiceRepository.Edit(abono);
                    _unitOfWork.Commit();
                    return new ActualizarAbonoResponse($"Abono Actualizado Exitosamente");
                }
                return new ActualizarAbonoResponse($"Error al Actualizar Abono");

            }
        }
    }
}
