using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Grado.Aplicacion.Request
{
    public class ActualizarGradoRequest
    {
        public int id { get; set; }
        public String Nombre { get; set; }
    }
    public class ActualizarGradoResponse
    {
        public ActualizarGradoResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Grado Actualizado Exitosamente");
        }
    }
}
