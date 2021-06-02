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
        public CrearEstudianteCursoResponse Ejecutar(List<EstudianteCursoRequest> requests)
        {
            foreach (var item in requests)
            {
                IReadOnlyList<string> errors = item.CanCrear(item);
                if (errors.Any())
                {
                    string ListaErrors = "Errores: " + string.Join(",", errors);
                    return new CrearEstudianteCursoResponse(ListaErrors);
                }
                var estudianteCurso = _unitOfWork.EstudianteCursoServiceRepository.FindFirstOrDefault(t => t.IdCurso == item.IdCurso && t.IdEstudiante == item.IdEstudiante || t.Id == item.Id);
                if (estudianteCurso != null)
                {
                    return new CrearEstudianteCursoResponse($"Ya se agregó el estudiante al curso");
                }
                var newEstudianteCurso = new Dominio.EstudianteCurso(item.IdEstudiante, item.IdCurso);
                _unitOfWork.EstudianteCursoServiceRepository.Add(newEstudianteCurso);
            }
            _unitOfWork.Commit();
            return new CrearEstudianteCursoResponse($"Estudiantes se agregaron al curso correctamente");
        }
    }
}
