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

        public List<Dominio.Entidades.Nota> GetAll()
        {
            var res = _unitOfWork.NotaServiceRepository.FindBy();
            _unitOfWork.Dispose();
            return res.ToList();
        }

        public Dominio.Entidades.Nota GetId(int id)
        {
            var ConsultarID = _unitOfWork.NotaServiceRepository.Find(id);
            _unitOfWork.Dispose();
            return ConsultarID;
        }
    }
}
