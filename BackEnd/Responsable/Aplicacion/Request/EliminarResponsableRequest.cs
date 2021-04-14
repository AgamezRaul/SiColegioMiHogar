using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Responsable.Aplicacion.Request
{
    public class EliminarResponsableRequest
    {
        public int UsuarioId { get; set; }
    }
    public class EliminarResponsableResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Responsable Eliminado Exitosamente");
        }
    }
}
