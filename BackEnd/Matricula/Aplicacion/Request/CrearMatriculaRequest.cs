using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Matricula.Aplicacion.Request
{
   public class CrearMatriculaRequest
    {
        public int id { get; set; }
        public DateTime FecConfirmacion { get; set; }
        public int IdePreMatricula { get; set; }

    }
    public class CrearMatriculaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Matricula Creada Exitosamente");
        }
    }
}
