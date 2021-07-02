using System.Collections.Generic;

namespace BackEnd.EstudianteCurso.Aplicacion
{
    public class EstudianteCursoRequest
    {
        public int Id { get; set; }
        public string Estudiante { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }
        public IReadOnlyList<string> CanCrear(EstudianteCursoRequest request)
        {
            var errors = new List<string>();
            if (request.IdCurso == 0)
                errors.Add("Campo Curso vacio");
            if (request.IdEstudiante == 0)
                errors.Add("Campo Estudiante vacio");
            return errors;
        }
    }
    public class CrearEstudianteCursoResponse
    {
        public string Message { get; set; }
        public CrearEstudianteCursoResponse(string message)
        {
            Message = message;
        }
        public bool IsOk()
        {
            return this.Message.Equals("Estudiantes se agregaron al curso correctamente");
        }
    }
    public class ActualizarEstudianteCursoResponse
    {
        public ActualizarEstudianteCursoResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("Estudiante se agregó a un nuevo curso");
        }
    }
    public class EliminarEstudianteCursoResponse
    {
        public EliminarEstudianteCursoResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("Se eliminó correctamente el estudiante del curso");
        }
    }
}
