using BackEnd.Base;

namespace BackEnd.Periodo.Aplicacion.Services
{
    public class ConsultarPeriodoService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarPeriodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public Dominio.Periodo GetPeriodo(int id)
        {
            var periodo = _unitOfWork.PeriodoServiceRepository.Find(id);
            return periodo;
        }
    }
}
