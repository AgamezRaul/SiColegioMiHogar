using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.EstudianteCurso.Aplicacion
{
    public class EliminarEstudianteCursoService
    {
        readonly IUnitOfWork _unitOfWork;

        public EliminarEstudianteCursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarEstudianteCursoResponse Ejecutar(int id)
        {
            Dominio.EstudianteCurso estudiante = _unitOfWork.EstudianteCursoServiceRepository.FindFirstOrDefault(t => t.Id == id);
            if (estudiante == null)
            {
                return new EliminarEstudianteCursoResponse($"No existe ese estudiante en el curso");
            }
            _unitOfWork.EstudianteCursoServiceRepository.Delete(estudiante);
            _unitOfWork.Commit();
            return new EliminarEstudianteCursoResponse($"Se eliminó correctamente el estudiante del curso");
        }
    }
}
