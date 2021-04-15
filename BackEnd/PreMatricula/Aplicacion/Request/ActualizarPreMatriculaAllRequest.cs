using BackEnd.Estudiante.Aplicacion.Request;
using BackEnd.Responsable.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.PreMatricula.Aplicacion.Request
{
    public class ActualizarPreMatriculaAllRequest
    {
        public int id { get; set; }
        public DateTime FecPrematricula { get => DateTime.Now.Date; }
        public int IdUsuario { get; set; }
        public string Estado { get => "No confirmado"; }
        public List<ActualizarResponsableRequest> Responsables { get; set; }
        public ActualizarEstudianteRequest Estudiante { get; set; }
    }
    public class ActualizarPreMatriculaAllResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("PreMatricula Actualizada Exitosamente");
        }
    }
}
