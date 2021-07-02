using BackEnd.Base;
using BackEnd.NotaPeriodo.Aplicacion.Request;

namespace BackEnd.NotaPeriodo.Aplicacion.Service.Eliminar
{
    public class EliminarNotaPeriodoService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarNotaPeriodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarNotaPeriodoResponse Ejecutar(EliminarNotaPeriodoRequest request)
        {
            Dominio.NotaPeriodo notaPeriodo = _unitOfWork.NotaPeriodoServiceRepository.FindFirstOrDefault(t => t.Id == request.IdNotaPeriodo);
            if (notaPeriodo == null)
            {
                return new EliminarNotaPeriodoResponse() { Message = $"Nota Periodo no existe" };
            }
            else
            {
                _unitOfWork.NotaPeriodoServiceRepository.Delete(notaPeriodo);
                _unitOfWork.Commit();
                return new EliminarNotaPeriodoResponse() { Message = $"Nota Periodo Eliminado Exitosamente" };
            }
        }
    }
}
