using BackEnd.Abono.Aplicacion.Request;
using BackEnd.Base;

namespace BackEnd.Abono.Aplicacion.Service.Actualizar
{
    public class ActualizarAbonoService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarAbonoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarAbonoResponse Ejecutar(ActualizarAbonoRequest request)
        {
            Dominio.Abono abono = _unitOfWork.AbonoServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (abono == null)
            {
                return new ActualizarAbonoResponse($"Abono no existe");
            }
            else
            {
                abono.ValorAbono = request.ValorAbono;
                _unitOfWork.AbonoServiceRepository.Edit(abono);
                _unitOfWork.Commit();
                return new ActualizarAbonoResponse($"Abono Actualizado Exitosamente");

            }
        }
    }
}
