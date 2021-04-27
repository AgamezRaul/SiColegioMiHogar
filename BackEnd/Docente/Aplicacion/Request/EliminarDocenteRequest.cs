using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Docente.Aplicacion.Request
{
    public class EliminarDocenteRequest
    {
        public int IdDocente { get; set; }
    }
    public class EliminarDocenteResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Docente Eliminado Exitosamente");
        }
    }
}
