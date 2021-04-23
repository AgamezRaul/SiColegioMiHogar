using BackEnd.Base;
using BackEnd.Nota.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Nota.Aplicacion.Services
{
    public class ConsultarNotaService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarNotaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public Dominio.Entidades.Nota GetNota(int id)
        {
            var  nota = _unitOfWork.NotaServiceRepository.Find(id);
            return nota;
        }
    }
}
