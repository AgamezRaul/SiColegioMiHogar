using BackEnd.Base;
using BackEnd.Nota.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackEnd.Nota.Dominio;

namespace BackEnd.Materia.Aplicacion.Services.Consultar
{
    public class ConsultarMateriaService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarMateriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<Nota.Dominio.Entidades.Nota> GetAll()
        {
            var res = _unitOfWork.NotaServiceRepository.FindBy();
            _unitOfWork.Dispose();
            return res.ToList();
        }

        public Nota.Dominio.Entidades.Nota GetId(int id)
        {
            var ConsultarID = _unitOfWork.NotaServiceRepository.Find(id);
            _unitOfWork.Dispose();
            return ConsultarID;
        }
    }
}
