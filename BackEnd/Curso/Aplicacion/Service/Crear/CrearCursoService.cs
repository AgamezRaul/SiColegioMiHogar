using BackEnd.Base;
using BackEnd.Curso.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Curso.Aplicacion.Service.Crear
{
    public class CrearCursoService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearCursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearCursoResponse Ejecutar(CrearCursoRequest request)
        {
            var curso = _unitOfWork.CursoServiceRepository.FindFirstOrDefault(t => t.Id == request.id);
            if (curso == null)
            {
                Dominio.Curso newCurso = new Dominio.Curso(request.nombre, request.maxEstudiantes, request.idDirectorDocente);

                IReadOnlyList<string> errors = newCurso.CanCrear(newCurso);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearCursoResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.CursoServiceRepository.Add(newCurso);
                    _unitOfWork.Commit();
                    return new CrearCursoResponse() { Message = $"Curso Creado Exitosamente" };
                }
            }
            else
            {
                return new CrearCursoResponse() { Message = $"Curso ya existe" };
            }
        }
    }
}