using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackEnd.Nota.Dominio;
using BackEnd.materias.Dominio.Entidades;

namespace BackEnd.Materia.Aplicacion.Services.Consultar
{
    public class ConsultarMateriaService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarMateriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<Materias> GetAll()
        {
            var res = _unitOfWork.MateriaServiceRepository.FindBy();
            _unitOfWork.Dispose();
            return res.ToList();
        }

        public Materias GetId(int id)
        {
            var ConsultarID = _unitOfWork.MateriaServiceRepository.Find(id);
            _unitOfWork.Dispose();
            return ConsultarID;
        }
    }
}
