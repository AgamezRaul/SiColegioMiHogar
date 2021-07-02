using BackEnd.Abono.Aplicacion.Request;
using BackEnd.Base;
using BackEnd.Mensualidad.Aplicacion.Request;
using BackEnd.Mensualidad.Aplicacion.Service.Actualizar;

namespace BackEnd.Abono.Aplicacion.Service.Anular
{
    public class AnularAbonoService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ActualizarMensualidadRequest actualizarMensualidadRequest;
        readonly ActualizarMensualidadService actualizarMensialidadService;
        public AnularAbonoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            actualizarMensualidadRequest = new ActualizarMensualidadRequest();
            actualizarMensialidadService = new ActualizarMensualidadService(_unitOfWork);
        }
        public AnularAbonoResponse Ejecutar(AnularAbonoRequest request)
        {
            Dominio.Abono abono = _unitOfWork.AbonoServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            var mensualidad = _unitOfWork.MensualidadServiceRepository.FindFirstOrDefault(t => t.Id == abono.IdMensualidad);
            if (abono == null)
            {
                return new AnularAbonoResponse($"Abono no existe");
            }
            if (mensualidad == null)
            {
                return new AnularAbonoResponse($"Mensualidad No existe");
            }
            
            else
            {
                if (abono.EstadoAbono.Equals("Anulado"))
                {
                    return new AnularAbonoResponse($"El abono ya esta anulado");
                }
                else
                {
                    actualizarMensualidadRequest.Deuda = mensualidad.Deuda + abono.ValorAbono;
                    actualizarMensualidadRequest.id = mensualidad.Id;

                    var respuesta = actualizarMensialidadService.Ejecutar(actualizarMensualidadRequest);
                    if (respuesta.isOk())
                    {
                        abono.EstadoAbono = request.EstadoAbono;

                        _unitOfWork.AbonoServiceRepository.Edit(abono);
                        _unitOfWork.Commit();
                        return new AnularAbonoResponse($"Abono Anulado Exitosamente");

                    }
                }
                
                return new AnularAbonoResponse($"Error al Anular Abono");
            }
        }
    }
}
