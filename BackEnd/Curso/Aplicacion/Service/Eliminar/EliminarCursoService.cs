using BackEnd.Base;
using BackEnd.Curso.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Curso.Aplicacion.Service.Eliminar
{
    public class EliminarCursoService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarCursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarCursoResponse Ejecutar(EliminarCursoRequest request)
        {
            Dominio.Curso curso = _unitOfWork.CursoServiceRepository.FindFirstOrDefault(t => t.Id == request.IdCurso);
            if (curso == null)
            {
                return new EliminarCursoResponse() { Message = $"Curso no existe" };
            }
            else
            {
                _unitOfWork.CursoServiceRepository.Delete(curso);
                _unitOfWork.Commit();
                return new EliminarCursoResponse() { Message = $"Curso Eliminado Exitosamente" };
            }
        }
    }
}
