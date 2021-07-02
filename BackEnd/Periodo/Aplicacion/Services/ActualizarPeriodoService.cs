using BackEnd.Base;
using BackEnd.Periodo.Aplicacion.Request;

namespace BackEnd.Periodo.Aplicacion.Services
{
    public class ActualizarPeriodoService
    {
        readonly IUnitOfWork _unitOfWork;


        public ActualizarPeriodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public ActualizarPeriodoResponse ActualizarPeriodo(CrearPeriodoRequest request)
        {
            var Buscar = _unitOfWork.PeriodoServiceRepository.FindFirstOrDefault(P => P.Id == request.Id);
            if (Buscar != null)
            {
                Buscar.FechaFin = request.FechaFin;
                Buscar.FechaInicio = request.FechaInicio;
                Buscar.NombrePeriodo = request.NombrePeriodo;
                Buscar.NumeroPeriodo = request.NumeroPeriodo;
                Buscar.Id = request.Id;

                _unitOfWork.PeriodoServiceRepository.Edit(Buscar);
                if (_unitOfWork.Commit() > 0)
                {
                    return new ActualizarPeriodoResponse() { Message = $"Los datos del periodo fueron actualizados correctamente." };

                }
                else
                {
                    return new ActualizarPeriodoResponse() { Message = $"Ocurrio un error al tratar de actualizar el periodo." };

                }
            }
            else
            {
                return new ActualizarPeriodoResponse() { Message = $"No Existe ese periodo" };

            }

        }
    }

    public class ActualizarPeriodoResponse
    {
        public string Message { get; set; }
    }
}
