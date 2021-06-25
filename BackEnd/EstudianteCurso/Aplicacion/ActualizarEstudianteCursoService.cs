using BackEnd.Base;

namespace BackEnd.EstudianteCurso.Aplicacion
{
    public class ActualizarEstudianteCursoService
    {
        readonly IUnitOfWork _unitOfWork;

        public ActualizarEstudianteCursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActualizarEstudianteCursoResponse Ejecutar(EstudianteCursoRequest request)
        {
            Dominio.EstudianteCurso estudianteCurso = _unitOfWork.EstudianteCursoServiceRepository.FindFirstOrDefault(t => t.Id == request.Id);
            if (estudianteCurso == null)
            {
                return new ActualizarEstudianteCursoResponse($"No existe el estudiante en el curso");
            }
            estudianteCurso.IdCurso = request.IdCurso;
            estudianteCurso.IdEstudiante = request.IdEstudiante;
            _unitOfWork.EstudianteCursoServiceRepository.Edit(estudianteCurso);
            _unitOfWork.Commit();
            return new ActualizarEstudianteCursoResponse($"Estudiante se agregó a un nuevo curso");
        }
    }
}
