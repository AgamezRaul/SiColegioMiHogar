using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Estudiante.Aplicacion.Request
{
    public class EliminarEstudianteRequest
    {
        public int IdUsuario { get; set; }
    }
    public class EliminarEstudianteResponse
    {
        public EliminarEstudianteResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("PreMatricula Eliminado Exitosamente");
        }
    }
}
