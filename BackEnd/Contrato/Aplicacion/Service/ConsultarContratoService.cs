using BackEnd.Base;
using BackEnd.Periodo.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Contrato.Aplicacion.Service
{
    public class ConsultarContratoService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarContratoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public Dominio.Contrato GetContrato(int id)
        {
            var contrato = _unitOfWork.ContratoServiceRepository.Find(id);
            return contrato;
        }
    }
}
