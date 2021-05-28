using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.EstudianteCurso.Aplicacion
{
    public class CrearEstudianteCursoService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearEstudianteCursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearEstudianteCursoResponse Ejecutar(EstudianteCursoRequest request)
        {
            IReadOnlyList<string> errors = request.CanCrear(request);
            if (errors.Any())
            {
                string ListaErrors = "Errores: " + string.Join(",", errors);
                return new CrearEstudianteCursoResponse(ListaErrors);
            }
            var estudianteCurso = _unitOfWork.EstudianteCursoServiceRepository.FindFirstOrDefault(t => t.IdCurso == request.IdCurso && t.IdEstudiante == request.IdEstudiante || t.Id == request.Id);
            if (estudianteCurso != null)
            {
                return new CrearEstudianteCursoResponse($"Ya se agregó el estudiante al curso");
            }
            var newEstudianteCurso = new Dominio.EstudianteCurso(request.IdEstudiante, request.IdCurso);
            _unitOfWork.EstudianteCursoServiceRepository.Add(newEstudianteCurso);
            _unitOfWork.Commit();
            return new CrearEstudianteCursoResponse($"Estudiante se agrego al curso correctamente");
        }
    }
}
