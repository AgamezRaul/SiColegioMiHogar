using BackEnd.Base;
using BackEnd.Contrato.Aplicacion.Request;

namespace BackEnd.Contrato.Aplicacion.Service.Eliminar
{
    public class EliminarContratoService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarContratoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarContratoResponse Ejecutar(EliminarContratoRequest request)
        {
            Dominio.Contrato contrato = _unitOfWork.ContratoServiceRepository.FindFirstOrDefault(t => t.IdDocente == request.IdDocente);
            if (contrato == null)
            {
                return new EliminarContratoResponse() { Message = $"El contrato no existe" };
            }
            _unitOfWork.ContratoServiceRepository.Delete(contrato);
            _unitOfWork.Commit();
            return new EliminarContratoResponse() { Message = $"Contrato eliminado exitosamente" };
        }
    }
}
