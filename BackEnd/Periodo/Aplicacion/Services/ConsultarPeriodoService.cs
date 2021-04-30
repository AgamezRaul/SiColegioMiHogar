using BackEnd.Base;
using BackEnd.Periodo.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
