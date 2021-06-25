using BackEnd.Base;
using BackEnd.NotaPeriodo.Aplicacion.Request;

namespace BackEnd.NotaPeriodo.Aplicacion.Service.Actualizar
{
    public class ActualizarNotaPeriodoService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarNotaPeriodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarNotaPeriodoResponse Ejecutar(ActualizarNotaPeriodoRequest request)
        {
            Dominio.NotaPeriodo notaPeriodo = _unitOfWork.NotaPeriodoServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (notaPeriodo == null)
            {
                return new ActualizarNotaPeriodoResponse() { Message = $"Nota Periodo no existe" };
            }
            else
            {
                notaPeriodo.Nota = request.nota;
                notaPeriodo.Observacion = request.observacion;
                notaPeriodo.IdPeriodo = request.idPeriodo;
                notaPeriodo.IdMateria = request.idMateria;

                _unitOfWork.NotaPeriodoServiceRepository.Edit(notaPeriodo);
                _unitOfWork.Commit();
                return new ActualizarNotaPeriodoResponse() { Message = $"Nota Periodo Actualizado Exitosamente" };

            }
        }
    }
}
