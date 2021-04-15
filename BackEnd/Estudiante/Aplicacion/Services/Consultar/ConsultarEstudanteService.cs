using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackEnd.Nota.Dominio;
using BackEnd.Estudiante.Dominio;

namespace BackEnd.Estudiante.Aplicacion.Services.Consultar
{
    public class ConsultarEstudanteService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultarEstudanteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<Dominio.Estudiante> GetAll()
        {
            var res = _unitOfWork.EstudianteServiceRepository.FindBy();
            _unitOfWork.Dispose();
            return res.ToList();
        }

        public Dominio.Estudiante GetId(int id)
        {
            var ConsultarID = _unitOfWork.EstudianteServiceRepository.Find(id);
            _unitOfWork.Dispose();
            return ConsultarID;
        }
    }
}
