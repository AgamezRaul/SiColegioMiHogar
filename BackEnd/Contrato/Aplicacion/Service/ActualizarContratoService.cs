using BackEnd.Base;
using BackEnd.Contrato.Aplicacion.Request;

namespace BackEnd.Contrato.Aplicacion.Service
{
    public class ActualizarContratoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ActualizarContratoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarContratoResponse EjecutarActualizarContrato(ActualizarContratoRequest request)
        {
            Dominio.Contrato contrato = _unitOfWork.ContratoServiceRepository.FindFirstOrDefault(t => t.IdDocente == request.IdDocente);
            if (contrato == null)
            {
                return new ActualizarContratoResponse($"El  contrato del docente no existe");
            }
            else
            {
                contrato.FechaInicio = request.FechaInicio;
                contrato.FechaFin = request.FechaFin;
                contrato.Sueldo = request.Sueldo;
                _unitOfWork.ContratoServiceRepository.Edit(contrato);
                _unitOfWork.Commit();
                return new ActualizarContratoResponse($"El  contrato del docente  ha  sido actualizado exitosamente");
            }

        }
    }
}
