using BackEnd.Base;
using BackEnd.Curso.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Curso.Aplicacion.Service.Actualizar
{
    public class ActualizarCursoService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarCursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarCursoResponse Ejecutar(ActualizarCursoRequest request)
        {
            Dominio.Curso curso = _unitOfWork.CursoServiceRepository.FindFirstOrDefault(t => t.Ide == request.id);
            if (curso == null)
            {
                return new ActualizarCursoResponse() { Message = $"Curso no existe" };
            }
            else
            {
                curso.Ide = request.id;
                curso.Nombre = request.nombre;
                curso.IdDirectorDocente = request.idDirectorDocente;
                curso.MaxEstudiantes = request.maxEstudiantes;

                _unitOfWork.CursoServiceRepository.Edit(curso);
                _unitOfWork.Commit();
                return new ActualizarCursoResponse() { Message = $"Curso Actualizado Exitosamente" };

            }
        }
    }
}