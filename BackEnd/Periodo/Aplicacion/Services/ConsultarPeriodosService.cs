using BackEnd.Base;
using BackEnd.Periodo.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Periodo.Aplicacion.Services
{
    public class ConsultarPeriodosService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarPeriodosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<Dominio.Periodo> GetAll()
        {
            var res = _unitOfWork.PeriodoServiceRepository.FindBy();
            _unitOfWork.Dispose();
            return res.ToList();
        }
    }
}
