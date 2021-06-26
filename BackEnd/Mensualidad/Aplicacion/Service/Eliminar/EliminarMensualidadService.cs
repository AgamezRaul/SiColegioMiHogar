using BackEnd.Base;
using BackEnd.Mensualidad.Aplicacion.Request;

namespace BackEnd.Mensualidad.Aplicacion.Service.Eliminar
{
    public class EliminarMensualidadService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarMensualidadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarMensualidadResponse Ejecutar(EliminarMensualidadRequest request)
        {
            Dominio.Mensualidad mensualidad = _unitOfWork.MensualidadServiceRepository.FindFirstOrDefault(t => t.Id == request.IdMensualidad);

            if (mensualidad == null)
            {
                return new EliminarMensualidadResponse($"Mensualidad no existe");
            }
            Abono.Dominio.Abono abono = _unitOfWork.AbonoServiceRepository.FindFirstOrDefault(t => t.IdMensualidad == request.IdMensualidad);
            if (abono!=null)
            {
                return new EliminarMensualidadResponse($"Mensualidad cuenta con abonos, No se puede eliminar");
            }
            _unitOfWork.MensualidadServiceRepository.Delete(mensualidad);
            _unitOfWork.Commit();
            return new EliminarMensualidadResponse($"Mensualidad Eliminada Exitosamente");

        }
    }
}
