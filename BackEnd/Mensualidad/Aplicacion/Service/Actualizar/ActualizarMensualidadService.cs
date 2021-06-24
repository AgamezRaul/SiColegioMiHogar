using BackEnd.Base;
using BackEnd.Mensualidad.Aplicacion.Request;

namespace BackEnd.Mensualidad.Aplicacion.Service.Actualizar
{
    public class ActualizarMensualidadService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarMensualidadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarMensualidadResponse Ejecutar(ActualizarMensualidadRequest request)
        {
            Dominio.Mensualidad mensualidad = _unitOfWork.MensualidadServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (mensualidad == null)
            {
                return new ActualizarMensualidadResponse($"Mensualidad no existe");
            }
            else
            {
                mensualidad.Deuda = request.Deuda;
                mensualidad.Estado = request.Estado;
                _unitOfWork.MensualidadServiceRepository.Edit(mensualidad);
                _unitOfWork.Commit();
                return new ActualizarMensualidadResponse($"Mensualidad Actualizada Exitosamente");

            }
        }
    }
}
