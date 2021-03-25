using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.PreMatricula.Aplicacion.Request
{
    public class ActualizarPreMatriculaRequest
    {
        public int id { get; set; }
        public DateTime FecPrematricula { get; set; }
        public int IdResponsable { get; set; }
        public string Estado { get; set; }
    }
    public class ActualizarPreMatriculaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("PreMatricula Actualizada Exitosamente");
        }
    }
}
