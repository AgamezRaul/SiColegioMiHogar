using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Matricula.Aplicacion.Request
{
    public class ActualizarMatriculaRequest
    {
        public int id { get; set; }
        public DateTime FecConfirmacion { get => DateTime.Now.Date; }
        public int IdPreMatricula { get; set; }
        public double ValorMatricula { get; set; }

    }
    public class ActualizarMatriculaResponse
    {
        public ActualizarMatriculaResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Matricula Actualizada Exitosamente");
        }
    }
}
