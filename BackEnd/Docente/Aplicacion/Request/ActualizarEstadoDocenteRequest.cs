using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Docente.Aplicacion.Request
{
    public class ActualizarEstadoDocenteRequest
    {
        public int IdDocente { get; set; }
        public string Estado { get => "Con contrato"; }
    }
    public class ActualizarEstadoDocenteResponse
    {
        public ActualizarEstadoDocenteResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Estado del Docente actualizado exitosamente");
        }
    }
}
